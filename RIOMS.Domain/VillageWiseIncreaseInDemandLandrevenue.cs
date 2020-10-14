namespace RIOMS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VillageWiseIncreaseInDemandLandrevenue")]
    public partial class VillageWiseIncreaseInDemandLandrevenue
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillageId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Year { get; set; }

        public decimal Current { get; set; }

        public decimal Previous { get; set; }

        public decimal Second { get; set; }

        public decimal Third { get; set; }

        public decimal MoreThanThree { get; set; }
    }
}
