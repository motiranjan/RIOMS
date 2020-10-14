namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Defaulter
    {
        public decimal? Area { get; set; }

        [StringLength(100)]
        public string KhataNo { get; set; }

        public string NameOfRT { get; set; }

        [StringLength(50)]
        public string Year { get; set; }

        public int? VillageId { get; set; }

        [Key]
        [Column(Order = 0)]
        public decimal DFC_MoreThanThree { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal DFC_Third { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal DFC_Second { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal DFC_Previous { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal DFC_Current { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal DFW_MoreThanThree { get; set; }

        [Key]
        [Column(Order = 6)]
        public decimal DFW_Third { get; set; }

        [Key]
        [Column(Order = 7)]
        public decimal DFW_Second { get; set; }

        [Key]
        [Column(Order = 8)]
        public decimal DFW_Previous { get; set; }

        [Key]
        [Column(Order = 9)]
        public decimal DFW_Current { get; set; }
    }
}
