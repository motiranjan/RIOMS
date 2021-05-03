namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IFormAbstractCess")]
    public partial class IFormAbstractCess
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Year { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IFormNo { get; set; }

        public decimal? MoreThanThree { get; set; }

        public decimal? Third { get; set; }

        public decimal? second { get; set; }

        public decimal? Previous { get; set; }

        public decimal? Current { get; set; }

        public decimal? InterestTotal { get; set; }
    }
}
