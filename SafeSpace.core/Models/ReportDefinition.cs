using System;
using System.Collections.Generic;
using System.Text;

namespace SafeSpace.core.Models
{
    public class ReportDefinition
    {
        public long Id { get; set; }
        public long Category { get; set; }
        public string Name { get; set; }
        public string DefinitionType { get; set; }
    }
}
