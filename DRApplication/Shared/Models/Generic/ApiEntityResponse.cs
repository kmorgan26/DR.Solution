using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Shared.Models.Generic
{
    public class ApiEntityResponse<TEntity> where TEntity : class
    {
        public bool Success { get; set; }
        public List<string> ErrorMessage { get; set; } = new List<string>();
        public TEntity Data { get; set; }

    }
}
