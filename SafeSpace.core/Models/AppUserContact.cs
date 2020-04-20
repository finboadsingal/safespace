using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SafeSpace.core.Models
{
    public class AppUserContact
    {
        public long Id { get; set; }
        public long AppUserId { get; set; }
        public long ContactAppUserId { get; set; }
        [MaxLength(20)]
        public string TrackingCategory { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
