using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Shared.Requests
{
    public  class AdhocRequest
    {
        public string Query { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public Dictionary<string, int>? Parameters { get; set; }

    }
}
