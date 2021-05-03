namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class VillageWiseDemandMiscRevenue
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillageId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Year { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal Current { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal Arrear { get; set; }
    }
}
