using DRApplication.Shared.Filters;
using DRApplication.Shared.Requests;
using DRApplication.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Shared.Interfaces;

public interface IAdHocRepository<TEntity> where TEntity : class
{
    Task<PagedResponse<TEntity>> GetAsync(QueryFilter<TEntity> Filter);
    Task<IEnumerable<TEntity>> Get(AdhocRequest adhocRequest);
    Task<TEntity> GetByIdAsync(object Id);

}