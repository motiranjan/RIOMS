namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("VillageWiseTahCollectionMiscRevenue")]
    public partial class VillageWiseTahCollectionMiscRevenue
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillageId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Year { get; set; }

        public decimal? Arrear { get; set; }

        public decimal? Current { get; set; }

        public decimal? Interest { get; set; }
    }
}
