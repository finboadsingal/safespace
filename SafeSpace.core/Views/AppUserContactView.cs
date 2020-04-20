using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SafeSpace.core.Views
{
    public class AppUserContactView
    {
        public long AppUserId { get; set; }
        [MaxLength(20)]
        public string TrackingCategory { get; set; }
        [MaxLength(50)]
        public string ContactEmail { get; set; }
        [MaxLength(15)]
        public string ContactPhone { get; set; }
        public DateTime ContactOn { get; set; }
    }
}
