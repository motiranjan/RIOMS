namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IFormAbstractMiscRevenue")]
    public partial class IFormAbstractMiscRevenue
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Year { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IFormNo { get; set; }

        public decimal? Arrear { get; set; }

        public decimal? Current { get; set; }

        public decimal? Interest { get; set; }
    }
}
