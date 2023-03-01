using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Flat
    {
        public Flat()
        {
            Facilities = new HashSet<Facility>();
            RentContracts = new HashSet<RentContract>();
        }

        public string Id { get; set; }
        public string Detail { get; set; }
        public int Price { get; set; }
        public int RoomNumber { get; set; }
        public string Status { get; set; }
        public string BuildingId { get; set; }
        public string FlatTypeId { get; set; }

        public virtual Building Building { get; set; }
        public virtual FlatType FlatType { get; set; }
        public virtual ICollection<Facility> Facilities { get; set; }
        public virtual ICollection<RentContract> RentContracts { get; set; }
    }
}
