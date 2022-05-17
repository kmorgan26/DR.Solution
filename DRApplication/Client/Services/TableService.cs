using DRApplication.Client.Interfaces;

namespace DRApplication.Client.Services
{
    public class TableService<TItem> : ITableService<TItem> where TItem : class
    {
        List<string> _headerNames = new();
        //private List<string>[]? _tableValues;
        
        public Task<IEnumerable<string>> GetHeaderNamesAsync(IEnumerable<TItem> items)
        {
            if (items is not null)
            {

                Type type = items.GetType().GetGenericArguments()[0];
                var property = type.GetProperties();

                foreach (var item in property)
                {
                    var name = item.Name;
                    _headerNames?.Add(name);
                }
                if (_headerNames is not null)
                    return Task.FromResult(_headerNames.AsEnumerable());
            }
            return null;
        }
        
    }
}
