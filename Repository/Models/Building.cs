using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Building
    {
        public Building()
        {
            Flats = new HashSet<Flat>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Flat> Flats { get; set; }
    }
}
