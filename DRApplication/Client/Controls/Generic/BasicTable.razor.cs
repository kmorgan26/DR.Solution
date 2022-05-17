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
    
    private void _setTableValues()
    {
        int count = 0;
        //Make a List<Maintainer>
        var myList = Data.ToList();
        //initialize the list
        _tableValues = new List<string>[myList.Count];
        //Iterate the list for each Maintainer
        foreach (var item in myList)
        {
            //Working on a single Maintainer
            //count the properties for current item
            //int count = item.GetType().GetProperties().Count();
            var newList = new List<string>();
            //Get the value of each property in the object
            foreach (var property in item.GetType().GetProperties())
            {
                var value = property.GetValue(item, null).ToString();
                newList.Add(value);
            }

            _tableValues[count] = newList;
            count++;
        }
    }

    protected override async Task OnInitializedAsync()
    {
        //await Task.Run(() => _setPropertyNames());
        _headerNames = await TableService.GetHeaderNamesAsync(Data);
        _setTableValues();
    }
}