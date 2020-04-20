using System;
using System.Collections.Generic;
using System.Text;

namespace SafeSpace.core.Models
{
    public class AppUserReportItemDetail
    {
        public long Id { get; set; }
        public long ReportId { get; set; }
        public long ItemDefinitionId { get; set; }
        public bool? BoolValue { get; set; }
        public int? IntValue { get; set; }
    }
}
