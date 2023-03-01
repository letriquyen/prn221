using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class FlatType
    {
        public FlatType()
        {
            Flats = new HashSet<Flat>();
        }

        public string Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Flat> Flats { get; set; }
    }
}
