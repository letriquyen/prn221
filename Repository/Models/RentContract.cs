using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class RentContract
    {
        public string Id { get; set; }
        public string Contract { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Status { get; set; }
        public int Value { get; set; }
        public string CustomerId { get; set; }
        public string FlatId { get; set; }
        public DateTime? StartDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Flat Flat { get; set; }
    }
}
