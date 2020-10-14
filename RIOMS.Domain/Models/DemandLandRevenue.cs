namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DemandLandRevenue
    {
     
        public string KhataNo { get; set; }

      
        public int VillageId { get; set; }

       
        public string Year { get; set; }

        public decimal Current { get; set; }

        public decimal Previous { get; set; }

        public decimal Second { get; set; }

        public decimal Third { get; set; }

        public decimal MoreThanThree { get; set; }

        public decimal Advance { get; set; }
        public virtual Khata Khata { get; set; }
    }
}
