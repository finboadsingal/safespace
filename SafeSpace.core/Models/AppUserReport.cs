using System;
using System.Collections.Generic;
using System.Text;

namespace SafeSpace.core.Models
{
    public class AppUserReport
    {
        public long Id { get; set; }
        public long AppUserId { get; set; }
        public string ReportCategory { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
