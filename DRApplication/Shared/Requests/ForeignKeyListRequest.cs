using DRApplication.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRApplication.Shared.Requests;

public class ForeignKeyListRequest
{
    public string TableName { get; set; }

    public string ForeignKeyName { get; set; }

    public string ForeignKeyValue { get; set; }

}
