using Dapper;
using DRApplication.Shared.Enums;
using DRApplication.Shared.Filters;
using DRApplication.Shared.Responses;
using System.Text;

namespace DRApplication.Shared.Services
{
    public class SqlQueryBuilder<TEntity> where TEntity : class
    {
        private SqlQueryPacket _sqlQueryBuilderResponse { get; set; } = new();
        private Dictionary<string, object> _filterProperties { get; set; } = new();

        private QueryFilter<TEntity> _queryFilter = new();
        private string _entityName;
        private StringBuilder _sb = new();

        public SqlQueryBuilder(QueryFilter<TEntity> filter, string entityName)
        {
            _queryFilter = filter;
            _entityName = entityName;
        }

        public SqlQueryPacket GetSqlPacket()
        {
            BuildQuery();
            return _sqlQueryBuilderResponse;
        }
        public SqlQueryPacket GetSqlCountPacket()
        {
            _sb = new();
            BuildCountQuery();
            return _sqlQueryBuilderResponse;
        }
        public void BuildCountQuery()
        {
            SetFilterProperties();
            SetCountSelectStatement();
            SetFromClause();
            SetWhereClause();

            SetQuery();
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
                _filterProperties.Add(column.Name, column.Value);
            }
            _sqlQueryBuilderResponse.DynamicParameters = new DynamicParameters(_filterProperties);
        }
        private void SetSelectStatement()
        {
            _sb.Append("SELECT ");

            if (_queryFilter.IncludePropertyNames.Count > 0)
            {
                foreach (var propertyName in _queryFilter.IncludePropertyNames)
                {
                    _sb.Append(propertyName);
                    if (propertyName != _queryFilter.IncludePropertyNames.Last())
                    {
                        _sb.Append(", ");
                    }
                }
            }
            else
            {
                _sb.Append("* ");
            }
        }
        private void SetFromClause()
        {
            _sb.Append("FROM ");
            _sb.Append(_entityName);
        }
        private void SetWhereClause()
        {
            if (_filterProperties.Count > 0)
            {
                _sb.Append(" WHERE ");

                int count = 0;

                foreach (var key in _filterProperties.Keys)
                {
                    _sb.Append(key);
                    switch (_queryFilter.FilterProperties[count].Operator)
                    {
                        case FilterQueryOperator.Equals:
                            _sb.Append(" = @");
                            _sb.Append(key);
                            break;
                        case FilterQueryOperator.NotEquals:
                            _sb.Append(" <> @");
                            _sb.Append(key);
                            break;
                        case FilterQueryOperator.StartsWith:
                            _sb.Append(" like @");
                            _sb.Append(key);
                            _sb.Append(" + '%' ");
                            break;
                        case FilterQueryOperator.EndsWith:
                            _sb.Append(" like '%' + @");
                            _sb.Append(key);
                            break;
                        case FilterQueryOperator.Contains:
                            _sb.Append(" like '%' + @");
                            _sb.Append(key);
                            _sb.Append(" + '%' ");
                            break;
                        case FilterQueryOperator.LessThan:
                            _sb.Append(" < @");
                            _sb.Append(key);
                            break;
                        case FilterQueryOperator.LessThanOrEqual:
                            _sb.Append(" =< @");
                            _sb.Append(key);
                            break;
                        case FilterQueryOperator.GreaterThan:
                            _sb.Append(" > @");
                            _sb.Append(key);
                            break;
                        case FilterQueryOperator.GreaterThanOrEqual:
                            _sb.Append(" >= @");
                            _sb.Append(key);
                            break;
                    }

                    if (_queryFilter.FilterProperties[count].CaseSensitive)
                    {
                        _sb.Append("COLLATE Latin1_General_CS_AS ");
                    }

                    if (key != _filterProperties.Keys.Last())
                    {
                        _sb.Append(" AND ");
                    }
                    count++;
                }
            }
        }
        private void SetOrderByClause()
        {
            if (_queryFilter.OrderByPropertyName != "")
            {
                _sb.Append(" ORDER BY ");
                _sb.Append(_queryFilter.OrderByPropertyName);

                if (_queryFilter.OrderByDescending)
                    _sb.Append(" DESC ");
            }
        }
        private void SetPagination()
        {
            if (_queryFilter.PaginationFilter is not null)
            {
                var offset = ( _queryFilter.PaginationFilter.PageNumber * _queryFilter.PaginationFilter.PageSize) - _queryFilter.PaginationFilter.PageSize;

                _sb.Append(" OFFSET ");
                _sb.Append(offset);
                _sb.Append(" ROWS ");
                _sb.Append(" FETCH NEXT ");
                _sb.Append(_queryFilter.PaginationFilter.PageSize);
                _sb.Append(" ROWS ONLY ");
            }
        }
        private void SetQuery()
        {
            _sqlQueryBuilderResponse.SqlQuery = _sb.ToString();
        }
        private void SetCountSelectStatement()
        {
            _sb.Append("SELECT COUNT(*) ");
        }
    }
}
