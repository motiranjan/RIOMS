namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TahCollectionMiscRevenue
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

        public virtual TahReceipt TahReceipt { get; set; }
    }
}
