namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IFormAbstractOLR")]
    public partial class IFormAbstractOLR
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Year { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IFormNo { get; set; }

        public decimal? Premium { get; set; }

        public decimal? DemarcationFee { get; set; }
    }
}
