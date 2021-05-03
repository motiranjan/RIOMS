namespace RIOMS.Domain.Models
{
    using System;

    public partial class IFormDetailMiscRevenue
    {

        public DateTime DepositeDate { get; set; }


        public int IFormNo { get; set; }

        public int? VillageId { get; set; }


        public string Year { get; set; }

        public decimal? Arrear { get; set; }

        public decimal? Current { get; set; }

        public decimal? Interest { get; set; }


        public int RICId { get; set; }

        public virtual IForm IForm { get; set; }
    }
}
