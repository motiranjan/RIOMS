namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CollectionMiscRevenue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceiptNo { get; set; }

        public string Type { get; set; }

        [StringLength(100)]
        public string CaseNo { get; set; }

        public decimal Current { get; set; }

        public decimal Arrear { get; set; }

        public decimal Interest { get; set; }

        public int MiscId { get; set; }

        public virtual Receipt Receipt { get; set; }
        public virtual MiscRevenue MiscRevenue { get; set; }
    }
}
