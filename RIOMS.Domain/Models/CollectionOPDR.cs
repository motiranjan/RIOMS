namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CollectionOPDR")]
    public partial class CollectionOPDR
    {
        public int? CaseNo { get; set; }

        [StringLength(50)]
        public string Year { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceiptNo { get; set; }

        public decimal Amount { get; set; }

        public virtual Receipt Receipt { get; set; }
    }
}
