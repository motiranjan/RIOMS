using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RIOMS.Domain.Models
{
   public  class CollectionPartOneRev : PartOneRev
    {
        public int ReceiptNo { get; set; }
        public decimal? InterestTotal { get; set; }
        public decimal? Advance { get; set; }

    }
    public partial class CollectionCess : CollectionPartOneRev
    {
        public virtual Receipt Receipt { get; set; }
    }
    public partial class CollectionWaterTax : CollectionPartOneRev

    {
        public virtual Receipt Receipt { get; set; }
    }
    public partial class CollectionLandRevenue : CollectionPartOneRev
    {
        public virtual Receipt Receipt { get; set; }
    }
}
