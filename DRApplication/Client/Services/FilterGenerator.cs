using DRApplication.Shared.Enums;
using DRApplication.Shared.Filters;

namespace DRApplication.Client.Services;

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
    public QueryFilter<TEntity> GetFilterWherePropertyEqualsValue(string propertyName, int id)
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
    public QueryFilter<TEntity> GetSinglePageWherePropertyEqualValue(string propertyName, int id)
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
        filter.PaginationFilter = new PaginationFilter()
        {
            PageNumber = 1,
            PageSize = 10
        };

        filter.FilterProperties = filterProperties;

        return filter;
    }
    public QueryFilter<TEntity> GetFilterWherePropertyEqualsValues(string propertyName, List<string> ids)
    {
        var filter = new QueryFilter<TEntity>();
        var filterProperties = new List<FilterProperty>();
        foreach (var i in ids)
        {
            filterProperties.Add(new FilterProperty()
            {
                Name = propertyName,
                Value = i,
                Operator = FilterQueryOperator.Equals
            });
        }
        filter.OrderByDescending = true;
        filter.OrderByPropertyName = "Id";
        filter.PaginationFilter = null;
        filter.FilterProperties = filterProperties;
        return filter;
    }
    public QueryFilter<TEntity> GetFilterForPropertyByListOfIds(string properyName, List<string> ids)
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

