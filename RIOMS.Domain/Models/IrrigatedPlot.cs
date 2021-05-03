namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IrrigatedPlot")]
    public partial class IrrigatedPlot
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillageId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string PlotNo { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal Area { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MIPType { get; set; }
    }
}
