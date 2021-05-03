namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IFormAbstractOther")]
    public partial class IFormAbstractOther
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Year { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IFormNo { get; set; }

        public decimal? Amount { get; set; }
    }
}
