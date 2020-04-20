using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SafeSpace.core.Models
{
    public class ReportItemDefinition
    {
        public long Id { get; set; }
        [MaxLength(20)]
        public string Category { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string DefinitionType { get; set; }
        public int Rating { get; set; }
        public int NotReportedRating { get; set; }
        public int Scale { get; set; }
    }
}
