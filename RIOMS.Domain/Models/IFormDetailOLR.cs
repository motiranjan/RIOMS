namespace RIOMS.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("IFormDetailOLR")]
    public partial class IFormDetailOLR
    {

        public int IFormNo { get; set; }


        public DateTime DepositeDate { get; set; }

        public int? VillageId { get; set; }


        public string Year { get; set; }

        public decimal? Premium { get; set; }

        public decimal? DemarcationFee { get; set; }


        public int RICId { get; set; }

        public virtual IForm IForm { get; set; }
    }
}
