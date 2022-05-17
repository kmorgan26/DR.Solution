using DRApplication.Client.Interfaces;

namespace DRApplication.Client.Services
{
    public class TableService<TItem> : ITableService<TItem> where TItem : class
    {
        List<string> _headerNames = new();
        private List<string>[]? _tableValues;
        
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

        public Task<List<string>[]> GetTableValues(IEnumerable<TItem> items)
        {
            int count = 0;

            var myList = items.ToList();
            
            //initialize the list
            _tableValues = new List<string>[myList.Count];

            //Iterate the list for each Item
            foreach (var item in myList)
            {
                //Working on a single Item
                //count the properties for current item
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
            return Task.FromResult(_tableValues);
        }
        
    }
}
