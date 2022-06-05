using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Shared.Enums
{
    public enum FilterQueryOperator
    {
        Equals,
        NotEquals,
        StartsWith,
        EndsWith,
        Contains,
        LessThan,
        GreaterThan,
        LessThanOrEqual,
        GreaterThanOrEqual,
        In
    }
}
