namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CollectionOLR")]
    public partial class CollectionOLR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReceiptNo { get; set; }

        public int CaseId { get; set; }

        public decimal? Premium { get; set; }

        public decimal? DemarcationFee { get; set; }

        public virtual Receipt Receipt { get; set; }
    }
}
