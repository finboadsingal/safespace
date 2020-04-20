using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SafeSpace.core.Models
{
    public class ContactRiskDefinition
    {
        public long Id { get; set; }
        [MaxLength(20)]
        public string Category { get; set; }
        public int DaysStart { get; set; }
        public int DaysEnd { get; set; }
        public int RatingStart { get; set; }
        public int RatingEnd { get; set; }
        public int Rating { get; set; }
    }
}
