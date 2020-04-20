using System;
using System.Collections.Generic;
using System.Text;

namespace SafeSpace.core.Views
{
    public class RatingView
    {
        public long AppUserId { get; set; }
        public decimal Rating { get; set; }
        public string Risk { get; set; }
    }
}
