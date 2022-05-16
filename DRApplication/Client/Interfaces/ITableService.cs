namespace DRApplication.Client.Interfaces;

using Microsoft.AspNetCore.Components;
using MudBlazor;

public interface ITableService<TEntity> where TEntity : class
{
    RenderFragment<TEntity> GetRowTemplate(List<string> ValueList);

    MudTable<TEntity> GetMudTable(IEnumerable<TEntity> entities);

}
