using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Shared.Responses
{
    public  class SqlQueryWithDynamicParameters
    {
        public string? QueryToRun { get; set; }
        public DynamicParameters? DynamicParameters { get; set; }
    }
}
