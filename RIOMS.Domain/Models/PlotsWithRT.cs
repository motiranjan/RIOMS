namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PlotsWithRT")]
    public partial class PlotsWithRT
    {
        public string Name { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string KhataNo { get; set; }

        public string NameOfRT { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string PlotNo { get; set; }

        [StringLength(255)]
        public string Kisam { get; set; }

        public decimal? Area { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillageId { get; set; }
    }
}
