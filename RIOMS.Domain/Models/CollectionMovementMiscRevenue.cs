namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CollectionMovementMiscRevenue
    {
        
        public long id { get; set; }

        public int FromVillageId { get; set; }

        public int ToVillageId { get; set; }

      
        public string Year { get; set; }

        public decimal? Current { get; set; }

        public decimal? Arrear { get; set; }
        public virtual Village FromVillage { get; internal set; }
        public virtual Village ToVillage { get; internal set; }
    }
}
