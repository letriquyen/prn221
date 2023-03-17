using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string Rent { get; set; }
        public string Water { get; set; }
        public string Electricity { get; set; }
        public string Management { get; set; }
        public string Parking { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime? Date { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
