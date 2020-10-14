namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VillageWiseTahCollectionCess
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillageId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Year { get; set; }

        public decimal? Current { get; set; }

        public decimal? Previous { get; set; }

        public decimal? Second { get; set; }

        public decimal? Third { get; set; }

        public decimal? MoreThanThree { get; set; }

        public decimal? InterestTotal { get; set; }
    }
}
