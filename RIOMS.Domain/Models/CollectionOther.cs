namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class CollectionOther
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceiptNo { get; set; }

        [StringLength(100)]
        public string Type { get; set; }

        public decimal? Amount { get; set; }

        [StringLength(100)]
        public string CaseNo { get; set; }

        public virtual Receipt Receipt { get; set; }
    }
}
