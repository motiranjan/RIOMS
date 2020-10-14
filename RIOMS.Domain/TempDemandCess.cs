namespace RIOMS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TempDemandCess")]
    public partial class TempDemandCess
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

        [Key]
        [Column(Order = 3)]
        public decimal Current { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Previous { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal Second { get; set; }

        [Key]
        [Column(Order = 6)]
        public decimal Third { get; set; }

        [Key]
        [Column(Order = 7)]
        public decimal MoreThanThree { get; set; }

        [Key]
        [Column(Order = 8)]
        public decimal Advance { get; set; }

        public decimal? Annual { get; set; }
    }
}
