namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TahReceipt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceiptNo { get; set; }

        public int VillageId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Year { get; set; }

        [StringLength(100)]
        public string KhataNo { get; set; }

        public int? MIscId { get; set; }

        public virtual MiscRevenue MiscRevenue { get; set; }

        public virtual TahCollectionCess TahCollectionCess { get; set; }

        public virtual TahCollectionLandRevenue TahCollectionLandRevenue { get; set; }

        public virtual TahCollectionMiscRevenue TahCollectionMiscRevenue { get; set; }

        public virtual TahCollectionWaterTax TahCollectionWaterTax { get; set; }
    }
}
