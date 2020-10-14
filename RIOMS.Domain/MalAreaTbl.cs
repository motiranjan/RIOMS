namespace RIOMS.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MalAreaTbl")]
    public partial class MalAreaTbl
    {
        [Key]
        [StringLength(100)]
        public string KhataNo { get; set; }

        public string NameOfRT { get; set; }

        public decimal? MalArea { get; set; }
    }
}
