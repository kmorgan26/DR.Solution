using DRApplication.Client.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using MudBlazor;

namespace DRApplication.Client.Services
{
    public class TableService<TEntity> : ITableService<TEntity> where TEntity : class
    {
        public MudTable<TEntity> GetMudTable(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public RenderFragment<TEntity> GetRowTemplate(List<string> ValueList)
        {
            throw new NotImplementedException();
        }
    }
}
