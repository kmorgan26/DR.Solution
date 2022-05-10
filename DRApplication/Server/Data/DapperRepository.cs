using Dapper;
using Dapper.Contrib.Extensions;
using DRApplication.Shared.Enums;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Helpers;
using DRApplication.Shared.Interfaces;
using DRApplication.Shared.Responses;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DRApplication.Server.Data
{
    public class DapperRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private string _sqlConnectionString;
        private string entityName;
        private Type entityType;

        private string primaryKeyName;
        private string primaryKeyType;
        private bool PKNotIdentity = false;

        public DapperRepository(string sqlConnectionString)
        {
            _sqlConnectionString = sqlConnectionString;
            entityType = typeof(TEntity);
            entityName = GetTableName.GetTableNameFromClass(entityType.Name);

            var props = entityType.GetProperties().Where(
                prop => Attribute.IsDefined(prop,
                typeof(KeyAttribute)));
            if (props.Count() > 0)
            {
                primaryKeyName = props.First().Name;
                primaryKeyType = props.First().PropertyType.Name;
            }
            else
            {
                // Default
                primaryKeyName = "Id";
                primaryKeyType = "Int32";
            }

            // look for [ExplicitKey]
            props = entityType.GetProperties().Where(
                prop => Attribute.IsDefined(prop,
                typeof(ExplicitKeyAttribute)));
            if (props.Count() > 0)
            {
                PKNotIdentity = true;
                primaryKeyName = props.First().Name;
                primaryKeyType = props.First().PropertyType.Name;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAsync(QueryFilter<TEntity> Filter)
        {
            SqlQueryBuilder<TEntity> sqlQueryBuilder = new SqlQueryBuilder<TEntity>(Filter, entityName);

            using (IDbConnection db = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    var response = sqlQueryBuilder.GetSqlResponse();
                    var query = response.QueryToRun;
                    var parameters = response.DynamicParameters;

                    var result = await db.QueryAsync<TEntity>(query, parameters);

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return (IEnumerable<TEntity>)new List<TEntity>();
                }
            }
        }
        public async Task<TEntity> GetByIdAsync(object Id)
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionString))
            {
                db.Open();
                var item = db.Get<TEntity>(Id);
                return await Task.FromResult(item);
            }
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionString))
            {
                db.Open();
                return await db.GetAllAsync<TEntity>();
            }
        }
        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionString))
            {
                db.Open();
                // start a transaction in case something goes wrong
                await db.ExecuteAsync("begin transaction");
                try
                {
                    // Get the primary key property
                    var prop = entityType.GetProperty(primaryKeyName);

                    // int key?
                    if (primaryKeyType == "Int32")
                    {
                        // not an identity?
                        if (PKNotIdentity == true)
                        {
                            // get the highest value
                            var sql = $"select max({primaryKeyName}) from {entityName}";
                            // and add 1 to it
                            var Id = Convert.ToInt32(db.ExecuteScalar(sql)) + 1;
                            // update the entity
                            prop.SetValue(entity, Id);
                            // do the insert
                            db.Insert<TEntity>(entity);
                        }
                        else
                        {
                            // key will be created by the database
                            var Id = (int)db.Insert<TEntity>(entity);
                            // set the value
                            prop.SetValue(entity, Id);
                        }
                    }
                    else if (primaryKeyType == "String")
                    {
                        // string primary key. Use my helper
                        string sql = DapperSqlHelper.GetDapperInsertStatement(entity, entityName);
                        await db.ExecuteAsync(sql, entity);
                    }
                    // if we got here, we're good!
                    await db.ExecuteAsync("commit transaction");
                    return entity;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    await db.ExecuteAsync("rollback transaction");
                    return null;
                }
            }
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionString))
            {
                db.Open();
                try
                {
                    await db.UpdateAsync<TEntity>(entity);
                    return entity;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public async Task<bool> DeleteAsync(TEntity entityToDelete)
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    await db.DeleteAsync<TEntity>(entityToDelete);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public async Task<bool> DeleteByIdAsync(object Id)
        {
            var item = await GetByIdAsync(Id);
            var status = await DeleteAsync(item);
            return status;
        }
        public Task DeleteAllAsync()
        {
            //too risky for me to implement this one.
            throw new NotImplementedException();
        }
        
    }
}