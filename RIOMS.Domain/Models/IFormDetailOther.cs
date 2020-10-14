namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IFormDetailOther
    {
       
        public int IFormNo { get; set; }

       
        public DateTime DepositeDate { get; set; }

        public int? VillageId { get; set; }

      
        public string Year { get; set; }

       
        public string Type { get; set; }

        public decimal? Amount { get; set; }

       
        public int RICId { get; set; }

        public virtual IForm IForm { get; set; }
    }
}
