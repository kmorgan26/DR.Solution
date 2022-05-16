using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Client.Services
{
    public class TableTemplateBuilder<TEntity> where TEntity : class
    {
        private readonly MudTable<TEntity> _mudTable;

        public TableTemplateBuilder(IEnumerable<TEntity> entities)
        {
            var type = entities.GetType().GetGenericArguments()[0];

            _mudTable = new MudTable<TEntity>();
        }

        public 
        
        public string GetHeaderTemplate()
        {
            StringBuilder sb = new();
            var entity = typeof(TEntity);
            var properties = entity.GetProperties();
            foreach(var property in properties)
            {
                sb.Append("<MudTh>");
                sb.Append(property.Name);
                sb.Append("</MudTh>");
            }
            
            return sb.ToString();
        }
    }
}
