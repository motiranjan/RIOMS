namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CollectionMovementCess
    {
       
        public long Id { get; set; }

    
        public int FromVillageId { get; set; }

       
        public int ToVillageId { get; set; }

    
        public string Year { get; set; }

        public decimal? Current { get; set; }

        public decimal? Previous { get; set; }

        public decimal? Second { get; set; }

        public decimal? Third { get; set; }

        public decimal? MoreThanThree { get; set; }

        public decimal? IntrestTotal { get; set; }
        public virtual Village ToVillage { get;  set; }
        public virtual Village FromVillage { get;  set; }
    }
}
