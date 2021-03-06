﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SafeSpace.core.Models
{
    public class AppUserReport
    {
        public long Id { get; set; }
        public long AppUserId { get; set; }
        [MaxLength(20)]
        public string Category { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<AppUserReportItemDetail> AppUserReportItemDetails { get; set; }
    }
}
