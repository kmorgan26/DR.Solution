using DRApplication.Client.Interfaces;
using Microsoft.AspNetCore.Components;
namespace DRApplication.Client.Controls.Generic;

public partial class BasicTable<TItem> where TItem : class
{
    [Parameter]
    public IEnumerable<TItem> Data { get; set; }

    [Inject]
    ITableService<TItem> TableService { get;set; }

    private List<string>[] _tableValues;
    private IEnumerable<string> _headerNames;
    private bool isBusy;

    protected override async Task OnInitializedAsync()
    {
        isBusy = true;
        _headerNames = await TableService.GetHeaderNamesAsync(Data);
        _tableValues = await TableService.GetTableValues(Data);
        isBusy = false;
    }
}