using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.TestProject
{
    public class FallbackServiceProvider : IServiceProvider
    {
        public object? GetService(Type serviceType)
        {
            return new DummyService();
        }
    }
    public class DummyService { }
}
