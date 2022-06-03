using DRApplication.Shared.Enums;
using DRApplication.Shared.Filters;

namespace DRApplication.Client.Services
{
    public class FilterGenerator<TEntity> where TEntity : class
    {
        public async Task<QueryFilter<TEntity>> GetFilterForPropertyByNameAsync(string propertyName, int id)
        {
            var filter = new QueryFilter<TEntity>();
            var filterProperties = new List<FilterProperty>();
            filterProperties.Add(new FilterProperty()
            { 
                Name = propertyName,
                Value = id.ToString(),
                Operator = FilterQueryOperator.Equals
            });
            filter.OrderByDescending = true;
            filter.OrderByPropertyName = "Id";
            filter.PaginationFilter = null;

            filter.FilterProperties = filterProperties;
            
            return filter;
        }
    }
}
