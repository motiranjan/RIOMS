namespace RIOMS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PartPlot
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string KhataNo { get; set; }

        public string SpecialCase { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillageId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string PlotNo { get; set; }
    }
}
