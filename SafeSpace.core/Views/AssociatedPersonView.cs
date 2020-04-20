using SafeSpace.core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeSpace.core.Views
{
    public class AssociatedPersonView
    {
        public Person AssociatedPerson { get; set; }
        public RatingView Rating { get; set; }
        public RatingView ContactRating { get; set; }
    }
}
