namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OLRCases")]
    public partial class OLRCas
    {
        public int VillageId { get; set; }

        public int CaseNo { get; set; }

        public int Year { get; set; }

        public int Id { get; set; }
    }
}
