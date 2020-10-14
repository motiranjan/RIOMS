using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIOMS.Domain.Models
{
    public class IFormDetailPartOneRevenue : PartOneRev
    {
        public int IFormNo { get; set; }

        public DateTime DepositeDate { get; set; }

        public int? VillageId { get; set; }

        public int RICId { get; set; }
        public string Year { get; set; }
        public decimal? InterestTotal { get; set; }
    }
    public partial class IFormDetailCess : IFormDetailPartOneRevenue
    {
        public virtual IForm IForm { get; set; }
    }
    public partial class IFormDetailLandRevenue : IFormDetailPartOneRevenue
    {
        public virtual IForm IForm { get; set; }
    }
    public partial class IFormDetailWaterTax :  IFormDetailPartOneRevenue
    {
        public virtual IForm IForm { get; set; }
    }
    
}