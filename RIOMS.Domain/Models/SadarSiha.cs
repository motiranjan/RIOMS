namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SadarSiha")]
    public partial class SadarSiha
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceiptNo { get; set; }

        public string Name { get; set; }

        public decimal? LandRevenue { get; set; }

        public decimal? Cess { get; set; }

        public decimal? WaterRate { get; set; }

        public decimal? MiscRevenueCurrent { get; set; }

        public decimal? MiscRevenueArrear { get; set; }

        public decimal? InterestLR { get; set; }

        public decimal? IntrestLR { get; set; }

        public decimal? IntrestMisc { get; set; }

        public decimal? IntrestCess { get; set; }

        public decimal? Amount { get; set; }
    }
}
