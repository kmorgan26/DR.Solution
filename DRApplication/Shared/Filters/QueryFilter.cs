using DRApplication.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace DRApplication.Shared.Filters
{
    public class QueryFilter<TEntity> where TEntity : class
    {
        /// <summary>
        /// If you want to return a subset of the properties, you can specify only
        /// the properties that you want to retrieve in the SELECT clause.
        /// Leave empty to return all columns
        /// </summary>
        public List<string> IncludePropertyNames { get; set; } = new List<string>();

        /// <summary>
        /// Defines the property names and values in the WHERE clause
        /// </summary>
        public List<FilterProperty> FilterProperties { get; set; } = new List<FilterProperty>();

        /// <summary>
        /// Specify the property to ORDER BY. Default is Id
        /// </summary>
        public string OrderByPropertyName { get; set; } = "Id";

        /// <summary>
        /// Set to true if you want to order DESCENDING
        /// </summary>
        public bool OrderByDescending { get; set; } = false;

        public PaginationFilter PaginationFilter { get; set; } = new ();

        /// <summary>
        /// A custome query that returns a list of entities with the current filter settings.
        /// </summary>
        /// <param name="AllItems"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetFilteredList(IEnumerable<TEntity> AllItems)
        {
            // Convert to IQueryable
            var query = AllItems.AsQueryable<TEntity>();

            // the expression will be used for each FilterProperty
            Expression<Func<TEntity, bool>> expression = null;

            // Process each property
            foreach (var filterProperty in FilterProperties)
            {
                // use reflection to get the property info
                PropertyInfo prop = typeof(TEntity).GetProperty(filterProperty.Name);

                // string
                if (prop is not null && prop.PropertyType == typeof(string))
                {
                    string value = filterProperty.Value.ToString();

                    if (filterProperty.CaseSensitive == false)
                        value = value.ToLower();

                    if (filterProperty.Operator == FilterQueryOperator.Equals)
                        if (filterProperty.CaseSensitive == false)
                            expression = s => s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString().ToLower() == value;
                        else
                            expression = s => s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString() == value;
                    else if (filterProperty.Operator == FilterQueryOperator.NotEquals)
                        if (filterProperty.CaseSensitive == false)
                            expression = s => s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString().ToLower() != value;
                        else
                            expression = s => s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString() != value;
                    else if (filterProperty.Operator == FilterQueryOperator.StartsWith)
                        if (filterProperty.CaseSensitive == false)
                            expression = s => s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString().ToLower().StartsWith(value);
                        else
                            expression = s => s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString().StartsWith(value);
                    else if (filterProperty.Operator == FilterQueryOperator.EndsWith)
                        if (filterProperty.CaseSensitive == false)
                            expression = s => s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString().ToLower().EndsWith(value);
                        else
                            expression = s => s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString().EndsWith(value);
                    else if (filterProperty.Operator == FilterQueryOperator.Contains)
                        if (filterProperty.CaseSensitive == false)
                            expression = s => s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString().ToLower().Contains(value);
                        else
                            expression = s => s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString().Contains(value);
                }
                // Int16
                else if (prop is not null && prop.PropertyType == typeof(Int16))
                {
                    int value = Convert.ToInt16(filterProperty.Value);

                    if (filterProperty.Operator == FilterQueryOperator.Equals)
                        expression = s => Convert.ToInt16(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) == value;
                    else if (filterProperty.Operator == FilterQueryOperator.NotEquals)
                        expression = s => Convert.ToInt16(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) != value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThan)
                        expression = s => Convert.ToInt16(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) < value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThan)
                        expression = s => Convert.ToInt16(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) > value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThanOrEqual)
                        expression = s => Convert.ToInt16(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) <= value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThanOrEqual)
                        expression = s => Convert.ToInt16(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) >= value;
                }
                // Int32
                else if (prop is not null && prop.PropertyType == typeof(Int32))
                {
                    int value = Convert.ToInt32(filterProperty.Value);

                    if (filterProperty.Operator == FilterQueryOperator.Equals)
                        expression = s => Convert.ToInt32(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) == value;
                    else if (filterProperty.Operator == FilterQueryOperator.NotEquals)
                        expression = s => Convert.ToInt32(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) != value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThan)
                        expression = s => Convert.ToInt32(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) < value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThan)
                        expression = s => Convert.ToInt32(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) > value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThanOrEqual)
                        expression = s => Convert.ToInt32(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) <= value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThanOrEqual)
                        expression = s => Convert.ToInt32(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) >= value;
                }
                // Int64
                else if (prop is not null && prop.PropertyType == typeof(Int64))
                {
                    Int64 value = Convert.ToInt64(filterProperty.Value);

                    if (filterProperty.Operator == FilterQueryOperator.Equals)
                        expression = s => Convert.ToInt64(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) == value;
                    else if (filterProperty.Operator == FilterQueryOperator.NotEquals)
                        expression = s => Convert.ToInt64(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) != value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThan)
                        expression = s => Convert.ToInt64(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) < value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThan)
                        expression = s => Convert.ToInt64(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) > value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThanOrEqual)
                        expression = s => Convert.ToInt64(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) <= value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThanOrEqual)
                        expression = s => Convert.ToInt64(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) >= value;
                }
                // UInt16
                else if (prop is not null && prop.PropertyType == typeof(UInt16))
                {
                    UInt16 value = Convert.ToUInt16(filterProperty.Value);

                    if (filterProperty.Operator == FilterQueryOperator.Equals)
                        expression = s => Convert.ToUInt16(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) == value;
                    else if (filterProperty.Operator == FilterQueryOperator.NotEquals)
                        expression = s => Convert.ToUInt16(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) != value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThan)
                        expression = s => Convert.ToUInt16(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) < value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThan)
                        expression = s => Convert.ToUInt16(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) > value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThanOrEqual)
                        expression = s => Convert.ToUInt16(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) <= value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThanOrEqual)
                        expression = s => Convert.ToUInt16(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) >= value;
                }
                // UInt32
                else if (prop is not null && prop.PropertyType == typeof(UInt32))
                {
                    UInt32 value = Convert.ToUInt32(filterProperty.Value);

                    if (filterProperty.Operator == FilterQueryOperator.Equals)
                        expression = s => Convert.ToUInt32(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) == value;
                    else if (filterProperty.Operator == FilterQueryOperator.NotEquals)
                        expression = s => Convert.ToUInt32(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) != value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThan)
                        expression = s => Convert.ToUInt32(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) < value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThan)
                        expression = s => Convert.ToUInt32(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) > value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThanOrEqual)
                        expression = s => Convert.ToUInt32(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) <= value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThanOrEqual)
                        expression = s => Convert.ToUInt32(s.GetType().GetProperty(filterProperty.Name).GetValue(s)) >= value;
                }
                // UInt64
                else if (prop is not null && prop.PropertyType == typeof(UInt64))
                {
                    UInt64 value = Convert.ToUInt64(filterProperty.Value);

                    if (filterProperty.Operator == FilterQueryOperator.Equals)
                        expression = s => Convert.ToUInt64(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) == value;
                    else if (filterProperty.Operator == FilterQueryOperator.NotEquals)
                        expression = s => Convert.ToUInt64(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) != value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThan)
                        expression = s => Convert.ToUInt64(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) < value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThan)
                        expression = s => Convert.ToUInt64(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) > value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThanOrEqual)
                        expression = s => Convert.ToUInt64(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) <= value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThanOrEqual)
                        expression = s => Convert.ToUInt64(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) >= value;
                }
                // DateTime
                else if (prop is not null && prop.PropertyType == typeof(DateTime))
                {
                    DateTime value = DateTime.Parse(filterProperty.Value);

                    if (filterProperty.Operator == FilterQueryOperator.Equals)
                        expression = s => DateTime.Parse(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) == value;
                    else if (filterProperty.Operator == FilterQueryOperator.NotEquals)
                        expression = s => DateTime.Parse(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) != value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThan)
                        expression = s => DateTime.Parse(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) < value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThan)
                        expression = s => DateTime.Parse(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) > value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThanOrEqual)
                        expression = s => DateTime.Parse(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) <= value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThanOrEqual)
                        expression = s => DateTime.Parse(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) >= value;
                }
                // decimal
                else if (prop is not null && prop.PropertyType == typeof(decimal))
                {
                    decimal value = Convert.ToDecimal(filterProperty.Value);

                    if (filterProperty.Operator == FilterQueryOperator.Equals)
                        expression = s => Convert.ToDecimal(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) == value;
                    else if (filterProperty.Operator == FilterQueryOperator.NotEquals)
                        expression = s => Convert.ToDecimal(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) != value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThan)
                        expression = s => Convert.ToDecimal(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) < value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThan)
                        expression = s => Convert.ToDecimal(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) > value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThanOrEqual)
                        expression = s => Convert.ToDecimal(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) <= value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThanOrEqual)
                        expression = s => Convert.ToDecimal(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) >= value;
                }
                // Single
                else if (prop is not null && prop.PropertyType == typeof(Single))
                {
                    Single value = Convert.ToSingle(filterProperty.Value);

                    if (filterProperty.Operator == FilterQueryOperator.Equals)
                        expression = s => Convert.ToSingle(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) == value;
                    else if (filterProperty.Operator == FilterQueryOperator.NotEquals)
                        expression = s => Convert.ToSingle(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) != value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThan)
                        expression = s => Convert.ToSingle(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) < value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThan)
                        expression = s => Convert.ToSingle(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) > value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThanOrEqual)
                        expression = s => Convert.ToSingle(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) <= value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThanOrEqual)
                        expression = s => Convert.ToSingle(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) >= value;
                }
                // Double
                else if (prop is not null && prop.PropertyType == typeof(Single))
                {
                    Double value = Convert.ToDouble(filterProperty.Value);

                    if (filterProperty.Operator == FilterQueryOperator.Equals)
                        expression = s => Convert.ToDouble(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) == value;
                    else if (filterProperty.Operator == FilterQueryOperator.NotEquals)
                        expression = s => Convert.ToDouble(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) != value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThan)
                        expression = s => Convert.ToDouble(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) < value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThan)
                        expression = s => Convert.ToDouble(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) > value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThanOrEqual)
                        expression = s => Convert.ToDouble(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) <= value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThanOrEqual)
                        expression = s => Convert.ToDouble(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) >= value;
                }
                // Boolean
                else if (prop is not null && prop.PropertyType == typeof(bool))
                {
                    bool value = Convert.ToBoolean(filterProperty.Value);

                    if (filterProperty.Operator == FilterQueryOperator.Equals)
                        expression = s => Convert.ToBoolean(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) == value;
                    else if (filterProperty.Operator == FilterQueryOperator.NotEquals)
                        expression = s => Convert.ToBoolean(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) != value;
                }
                // Byte
                else if (prop is not null && prop.PropertyType == typeof(Byte))
                {
                    Byte value = Convert.ToByte(filterProperty.Value);

                    if (filterProperty.Operator == FilterQueryOperator.Equals)
                        expression = s => Convert.ToByte(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) == value;
                    else if (filterProperty.Operator == FilterQueryOperator.NotEquals)
                        expression = s => Convert.ToByte(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) != value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThan)
                        expression = s => Convert.ToByte(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) < value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThan)
                        expression = s => Convert.ToByte(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) > value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThanOrEqual)
                        expression = s => Convert.ToByte(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) <= value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThanOrEqual)
                        expression = s => Convert.ToByte(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) >= value;
                }
                // Char
                else if (prop is not null && prop.PropertyType == typeof(Char))
                {
                    Char value = Convert.ToChar(filterProperty.Value);

                    if (filterProperty.Operator == FilterQueryOperator.Equals)
                        expression = s => Convert.ToChar(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) == value;
                    else if (filterProperty.Operator == FilterQueryOperator.NotEquals)
                        expression = s => Convert.ToChar(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) != value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThan)
                        expression = s => Convert.ToChar(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) < value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThan)
                        expression = s => Convert.ToChar(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) > value;
                    else if (filterProperty.Operator == FilterQueryOperator.LessThanOrEqual)
                        expression = s => Convert.ToChar(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) <= value;
                    else if (filterProperty.Operator == FilterQueryOperator.GreaterThanOrEqual)
                        expression = s => Convert.ToChar(s.GetType().GetProperty(filterProperty.Name).GetValue(s).ToString()) >= value;
                }
                // Add expression creation code for other data types here.

                // apply the expression
                query = query.Where(expression!);

            }

            // Include the specified properties
            foreach (var includeProperty in IncludePropertyNames)
            {
                query = query.Include(includeProperty);
            }

            // order by
            if (OrderByPropertyName != "")
            {
                PropertyInfo prop = typeof(TEntity).GetProperty(OrderByPropertyName);
                if (prop != null)
                {
                    if (OrderByDescending)
                        query = query.OrderByDescending(x => prop.GetValue(x, null));
                    else
                        query = query.OrderBy(x => prop.GetValue(x, null));
                }
            }

            // execute and return the list
            return query.ToList();
        }

    }
}
