using Dapper;
using DRApplication.Shared.Enums;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Responses;
using System.Text;

namespace DRApplication.Shared.Helpers
{
    public class SqlQueryBuilder<TEntity> where TEntity : class
    {
        private SqlQueryWithDynamicParameters _sqlQueryBuilderResponse { get; set; } = new();
        private QueryFilter<TEntity> _queryFilter;
        private string _entityName { get; set; }
        public Dictionary<string, object> FilterProperties { get; set; } = new();
        public StringBuilder sb { get; set; } = new();

        public SqlQueryBuilder(QueryFilter<TEntity> filter, string entityName)
        {
            _queryFilter = filter;
            _entityName = entityName;
        }

        public SqlQueryWithDynamicParameters GetSqlResponse()
        {
            BuildQuery();
            return _sqlQueryBuilderResponse;
        }
        public void BuildQuery()
        {
            SetFilterProperties();
            SetSelectStatement();
            SetFromClause();
            SetWhereClause();
            SetOrderByClause();
            SetPagination();
            
            SetQuery();
        }
        private void SetFilterProperties()
        {
            foreach (var column in _queryFilter.FilterProperties)
            {
                FilterProperties.Add(column.Name, column.Value);
            }
            _sqlQueryBuilderResponse.DynamicParameters = new DynamicParameters(FilterProperties);
        }
        private void SetSelectStatement()
        {
            sb.AppendLine("SELECT ");

            if (_queryFilter.IncludePropertyNames.Count > 0)
            {
                foreach (var propertyName in _queryFilter.IncludePropertyNames)
                {
                    sb.Append(propertyName);
                    if (propertyName != _queryFilter.IncludePropertyNames.Last())
                    {
                        sb.Append(", ");
                    }
                }
            }
            else
            {
                sb.Append("* ");
            }
        }
        private void SetFromClause()
        {
            sb.Append("FROM ");
            sb.Append(_entityName);
        }
        private void SetWhereClause()
        {
            if (FilterProperties.Count > 0)
            {
                sb.Append(" WHERE ");

                int count = 0;

                foreach (var key in FilterProperties.Keys)
                {
                    sb.Append(key);
                    switch (_queryFilter.FilterProperties[count].Operator)
                    {
                        case FilterQueryOperator.Equals:
                            sb.Append(" = @");
                            sb.Append(key);
                            break;
                        case FilterQueryOperator.NotEquals:
                            sb.Append(" <> @");
                            sb.Append(key);
                            break;
                        case FilterQueryOperator.StartsWith:
                            sb.Append(" like @");
                            sb.Append(key);
                            sb.Append(" + '%' ");
                            break;
                        case FilterQueryOperator.EndsWith:
                            sb.Append(" like '%' + @");
                            sb.Append(key);
                            break;
                        case FilterQueryOperator.Contains:
                            sb.Append(" like '%' + @");
                            sb.Append(key);
                            sb.Append(" + '%' ");
                            break;
                        case FilterQueryOperator.LessThan:
                            sb.Append(" < @");
                            sb.Append(key);
                            break;
                        case FilterQueryOperator.LessThanOrEqual:
                            sb.Append(" =< @");
                            sb.Append(key);
                            break;
                        case FilterQueryOperator.GreaterThan:
                            sb.Append(" > @");
                            sb.Append(key);
                            break;
                        case FilterQueryOperator.GreaterThanOrEqual:
                            sb.Append(" >= @");
                            sb.Append(key);
                            break;
                    }

                    if (_queryFilter.FilterProperties[count].CaseSensitive)
                    {
                        sb.Append("COLLATE Latin1_General_CS_AS ");
                    }

                    if (key != FilterProperties.Keys.Last())
                    {
                        sb.Append(" AND ");
                    }
                    count++;
                }
            }
        }
        private void SetOrderByClause()
        {
            if (_queryFilter.OrderByPropertyName != "")
            {
                sb.Append(" ORDER BY ");
                sb.Append(_queryFilter.OrderByPropertyName);

                if (_queryFilter.OrderByDescending)
                    sb.Append(" DESC ");
            }
        }
        private void SetPagination()
        {
            if (_queryFilter.PaginationFilter is not null)
            {
                var offset = _queryFilter.PaginationFilter.PageNumber - 1;

                sb.Append(" OFFSET ");
                sb.Append(offset);
                sb.Append(" ROWS ");
                sb.Append(" FETCH NEXT ");
                sb.Append(_queryFilter.PaginationFilter.PageSize);
                sb.Append(" ROWS ONLY ");
            }
        }
        private void SetQuery()
        {
            _sqlQueryBuilderResponse.QueryToRun = sb.ToString();
        }
    }
}
