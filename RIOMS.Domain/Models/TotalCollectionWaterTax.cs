namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TotalCollectionWaterTax")]
    public partial class TotalCollectionWaterTax
    {
        [Key]
        [StringLength(50)]
        public string Year { get; set; }

        public int? VillageId { get; set; }

        [StringLength(100)]
        public string KhataNo { get; set; }

        public decimal? MoreThanThree { get; set; }

        public decimal? Third { get; set; }

        public decimal? Second { get; set; }

        public decimal? Previous { get; set; }

        public decimal? Current { get; set; }
    }
}
