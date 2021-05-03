namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class IForm
    {
        public IForm()
        {
            IFormDetailCesses = new HashSet<IFormDetailCess>();
            IFormDetailWaterTaxes = new HashSet<IFormDetailWaterTax>();
            IFormDetailLandRevenues = new HashSet<IFormDetailLandRevenue>();
            IFormDetailMiscRevenues = new HashSet<IFormDetailMiscRevenue>();
            IFormDetailOLRs = new HashSet<IFormDetailOLR>();
            IFormDetailOthers = new HashSet<IFormDetailOther>();
            IFormDetailOPDRs = new HashSet<IFormDetailOPDR>();
        }

        public int IFormNo { get; set; }


        public string Year { get; set; }


        public int RICId { get; set; }

        [Column(TypeName = "date")]
        public DateTime FromDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ToDate { get; set; }

        public bool? IsDeposited { get; set; }

        [Column(TypeName = "date")]
        public DateTime DepositeDate { get; set; }
        public virtual ICollection<IFormDetailCess> IFormDetailCesses { get; set; }
        public virtual ICollection<IFormDetailWaterTax> IFormDetailWaterTaxes { get; set; }
        public virtual ICollection<IFormDetailLandRevenue> IFormDetailLandRevenues { get; set; }
        public virtual ICollection<IFormDetailMiscRevenue> IFormDetailMiscRevenues { get; set; }
        public virtual ICollection<IFormDetailOLR> IFormDetailOLRs { get; set; }
        public virtual ICollection<IFormDetailOther> IFormDetailOthers { get; set; }
        public virtual ICollection<IFormDetailOPDR> IFormDetailOPDRs { get; set; }
    }
}
