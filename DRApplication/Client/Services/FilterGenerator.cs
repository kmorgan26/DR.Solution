using DRApplication.Shared.Enums;
using DRApplication.Shared.Filters;

namespace DRApplication.Client.Services
{
    public class FilterGenerator<TEntity> where TEntity : class
    {
        /// <summary>
        /// This is for the WHERE Clause of an SQL Query.
        /// The Where clause will be written as: 
        /// 
        ///         WHERE propertyName = id
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<QueryFilter<TEntity>> GetFilterWherePropertyEqualsValueAsync(string propertyName, int id)
        {
            var filter = new QueryFilter<TEntity>();
            var filterProperties = new List<FilterProperty>();
            await Task.Run(() => filterProperties.Add(new FilterProperty()
            {
                Name = propertyName,
                Value = id.ToString(),
                Operator = FilterQueryOperator.Equals
            }));
            filter.OrderByDescending = true;
            filter.OrderByPropertyName = "Id";
            filter.PaginationFilter = null;

            filter.FilterProperties = filterProperties;

            return filter;
        }
        public async Task<QueryFilter<TEntity>> GetFilterWherePropertyEqualsValuesAsync(string propertyName, List<string> ids)
        {
            var filter = new QueryFilter<TEntity>();
            var filterProperties = new List<FilterProperty>();
            foreach (var i in ids)
            {
                await Task.Run(() =>filterProperties.Add(new FilterProperty()
                {
                    Name = propertyName,
                    Value = i,
                    Operator = FilterQueryOperator.Equals
                }));
            }
            filter.OrderByDescending = true;
            filter.OrderByPropertyName = "Id";
            filter.PaginationFilter = null;
            filter.FilterProperties = filterProperties;
            return filter;
        }
        
        //TODO: Use a List<string> as parameter
        public async Task<QueryFilter<TEntity>> GetFilterForPropertyByListOfIdsAsync(string properyName, List<string> ids)
        {
            var csvIds = string.Join(",", ids);
            var filter = new QueryFilter<TEntity>();
            var filterProperties = new List<FilterProperty>();
            filterProperties.Add(new FilterProperty()
            {
                Name = properyName,
                Value = csvIds,
                Operator = FilterQueryOperator.In
            });
            filter.OrderByDescending = true;
            filter.OrderByPropertyName = "Id";
            filter.PaginationFilter = null;
            filter.FilterProperties = filterProperties;
            return filter;
        }
    }
    
}
