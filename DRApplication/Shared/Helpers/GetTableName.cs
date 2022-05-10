using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Shared.Helpers
{
    public static class GetTableName
    {
        public static string GetTableNameFromClass(string className)
        {
            switch (className)
            {
                case "DeviceDiscovered" or "IssueObserved":
                    return className;
                case "GrfrHistory":
                    return "GrfrHistories";
                case "SimStatuses":
                    return "SimStatuses";
                default:
                    return $"{className}s p";
            }
        }
    }
}
