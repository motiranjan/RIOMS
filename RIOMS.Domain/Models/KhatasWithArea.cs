namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KhatasWithArea")]
    public partial class KhatasWithArea
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillageId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string KhataNo { get; set; }

        public string NameOfRT { get; set; }

        public decimal? Area { get; set; }
    }
}
