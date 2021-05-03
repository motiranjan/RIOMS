namespace RIOMS.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IFormDetailOPDR")]
    public partial class IFormDetailOPDR
    {

        public int IFormNo { get; set; }

        public DateTime DepositeDate { get; set; }

        public int? VillageId { get; set; }


        public string Year { get; set; }

        public decimal? Amount { get; set; }

        public int RICId { get; set; }

        public virtual IForm IForm { get; set; }
    }
}
