using DRApplication.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Shared.Filters
{
    public class TableJoin
    {
        public string PrimaryKeyName { get; set; } = "Id";
        public string ForeignTableName { get; set; } = string.Empty;
        public string ForeignTableAlias { get; set; } = string.Empty;
        public string ForeignKeyName { get; set; } = string.Empty;
        public JoinType JoinType { get; set; } = JoinType.INNER;

    }
}
