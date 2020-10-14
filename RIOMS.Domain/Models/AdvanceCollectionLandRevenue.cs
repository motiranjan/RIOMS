namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdvanceCollectionLandRevenue")]
    public partial class AdvanceCollectionLandRevenue
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string KhataNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillageId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Year { get; set; }

        public decimal? MoreThanThree { get; set; }

        public decimal? Third { get; set; }

        public decimal? Second { get; set; }

        public decimal? Previous { get; set; }

        public decimal? Current { get; set; }
    }
}
