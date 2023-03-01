using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Facility
    {
        public string Id { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public string FlatId { get; set; }

        public virtual Flat Flat { get; set; }
    }
}
