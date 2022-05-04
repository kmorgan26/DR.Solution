using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Shared.Helpers
{
    public class MappingHelper
    {
        public string ForeignKeyName { get; set; } = string.Empty;
        public string ForeignColumnName { get; set; }
        public IEnumerable<object> PrimaryEntities { get; set; }
        public IEnumerable<object> VMList { get; set; }
        public IEnumerable<object> ForeignEntities { get; set; }
    }
}
