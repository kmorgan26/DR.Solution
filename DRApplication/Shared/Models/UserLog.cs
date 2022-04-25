using System;
using System.Collections.Generic;

namespace DRApplication.Shared.Models
{
    public partial class UserLog
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string IpAddress { get; set; } = null!;
        public DateTime LoginDateTime { get; set; }
        public bool IsSuccess { get; set; }
    }
}
