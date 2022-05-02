﻿using Dapper;
using Dapper.Contrib.Extensions;
using DRApplication.Shared.Enums;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Interfaces;
using System.Data;
using System.Data.SqlClient;

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
            entityName = entityType.Name;

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
            using (IDbConnection db = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    // let's try this
                    var dictionary = new Dictionary<string, object>();
                    foreach (var column in Filter.FilterProperties)
                    {
                        dictionary.Add(column.Name, column.Value);
                    }
                    var parameters = new DynamicParameters(dictionary);
                    var sql = "select "; // * from products where ProductId = @ProductId";
                    if (Filter.IncludePropertyNames.Count > 0)
                    {
                        foreach (var propertyName in Filter.IncludePropertyNames)
                        {
                            sql += propertyName;
                            if (propertyName != Filter.IncludePropertyNames.Last())
                                sql += ", ";
                        }
                    }
                    else
                        sql += "* ";

                    sql += $"from {entityName} ";
                    if (dictionary.Count > 0)
                    {
                        sql += "where ";
                        int count = 0;


                        foreach (var key in dictionary.Keys)
                        {
                            switch (Filter.FilterProperties[count].Operator)
                            {
                                case FilterOperator.Equals:
                                    sql += $"{key} = @{key} ";
                                    break;
                                case FilterOperator.NotEquals:
                                    sql += $"{key} <> @{key} ";
                                    break;
                                case FilterOperator.StartsWith:
                                    sql += $"{key} like @{key} + '%' ";
                                    break;
                                case FilterOperator.EndsWith:
                                    sql += $"{key} like '%' + @{key} ";
                                    break;
                                case FilterOperator.Contains:
                                    sql += $"{key} like '%' + @{key} + '%' ";
                                    break;
                                case FilterOperator.LessThan:
                                    sql += $"{key} < @{key} ";
                                    break;
                                case FilterOperator.LessThanOrEqual:
                                    sql += $"{key} =< @{key} ";
                                    break;
                                case FilterOperator.GreaterThan:
                                    sql += $"{key} > @{key} ";
                                    break;
                                case FilterOperator.GreaterThanOrEqual:
                                    sql += $"{key} >= @{key} ";
                                    break;
                            }

                            if (Filter.FilterProperties[count].CaseSensitive)
                            {
                                sql += "COLLATE Latin1_General_CS_AS ";
                            }

                            if (key != dictionary.Keys.Last())
                            {
                                sql += "and ";
                            }
                            count++;
                        }
                    }
                    if (Filter.OrderByPropertyName != "")
                    {
                        sql += $"order by {Filter.OrderByPropertyName}";
                        if (Filter.OrderByDescending)
                        {
                            sql += " desc";
                        }
                    }

                    var result = await db.QueryAsync<TEntity>(sql, parameters);
                    return result;
                }
                catch (Exception ex)
                {
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
                //string sql = $"select * from {entityName}";
                //IEnumerable<TEntity> result = await db.QueryAsync<TEntity>(sql);
                //return result;
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
                    //string sql = DapperSqlHelper.GetDapperUpdateStatement(entity, entityName, primaryKeyName);
                    //await db.ExecuteAsync(sql, entity);
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
                //string sql = $"delete from {entityName} where {primaryKeyName}" +
                //    $" = @{primaryKeyName}";
                try
                {
                    //await db.ExecuteAsync(sql, entityToDelete);
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