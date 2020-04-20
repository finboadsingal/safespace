using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SafeSpace.core.Models
{
    public class Organization
    {
        public long Id { get; set; }
        [MaxLength(50)]

        public string Name { get; set; }
        [MaxLength(50)]

        public string Email { get; set; }
        [MaxLength(50)]
        public string ResponseEmail { get; set; }

        public ICollection<Person> AssociatedPersons  { get; set; }
    }
}
