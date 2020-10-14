namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Plot
    {
        public int Id { get; set; }

        public int? KhataId { get; set; }

        public int VillageId { get; set; }

        [Required]
        [StringLength(100)]
        public string KhataNo { get; set; }

        [Required]
        [StringLength(255)]
        public string PlotNo { get; set; }

        public int PlotNoOccurrence { get; set; }

        [StringLength(255)]
        public string Kisam { get; set; }

        [StringLength(255)]
        public string ChauhadiNorth { get; set; }

        public double? Acre { get; set; }

        public double? Decimal { get; set; }

        public decimal? Area { get; set; }

        public string Remark { get; set; }

        [StringLength(100)]
        public string ChakaName { get; set; }

        [StringLength(255)]
        public string ChauhadiSouth { get; set; }

        [StringLength(255)]
        public string ChauhadiEast { get; set; }

        [StringLength(255)]
        public string ChauhadiWest { get; set; }

        public bool? IsUpdated { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdatedOn { get; set; }

        public virtual Khata Khata { get; set; }

        public virtual Village Village { get; set; }
    }
}
