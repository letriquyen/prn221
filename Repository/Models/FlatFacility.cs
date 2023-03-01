using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class FlatFacility
    {
        public string FlatId { get; set; }
        public string FacilityId { get; set; }

        public virtual Facility Facility { get; set; }
        public virtual Flat Flat { get; set; }
    }
}
