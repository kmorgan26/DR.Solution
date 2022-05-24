using DRApplication.Client.Interfaces;
using DRApplication.Client.Requests;
using Microsoft.AspNetCore.Components;
namespace DRApplication.Client.Controls;

public partial class BasicTable<TItem> where TItem : class
{
    [Parameter]
    public TableRequest<TItem> Request { get; set; }

    [Inject]
    ITableService<TItem> TableService { get;set; }

    private List<string>[] _tableValues;
    private IEnumerable<string> _headerNames;
    private bool isBusy;

    protected override async Task OnInitializedAsync()
    {
        isBusy = true;
        _headerNames = await TableService.GetHeaderNamesAsync(Request.Data);
        _tableValues = await TableService.GetTableValues(Request.Data);
        isBusy = false;
    }
}