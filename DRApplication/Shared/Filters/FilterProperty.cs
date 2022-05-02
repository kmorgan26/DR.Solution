using DRApplication.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Shared.Filters
{
    public class FilterProperty
    {
        public string Name { get; set; } = "";
        public string Value { get; set; } = "";
        public FilterQueryOperator Operator { get; set; }
        public bool CaseSensitive { get; set; } = false;
    }
}
