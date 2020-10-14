namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IrrigatedPlotView")]
    public partial class IrrigatedPlotView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string KhataNo { get; set; }

        public string NameOfRT { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string PlotNo { get; set; }

        public decimal? Area { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal IrrArea { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string Remark { get; set; }
    }
}
