using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SafeSpace.core.Models
{
    public class RiskDefinition
    {
        public long Id { get; set; }
        [MaxLength(20)]
        public string Category { get; set; }
        public decimal RatingStart { get; set; }
        public decimal RatingEnd { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
