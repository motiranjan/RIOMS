using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RIOMS.Domain
{
    public class DemandPartOneRev:PartOneRev
    {
        public decimal Increase { get; set; }
    }

    public partial class DemandCess:DemandPartOneRev
    {

    }
    public partial class DemandWaterTax : DemandPartOneRev
    {

    }
    public partial class DemandLandRevenue : DemandPartOneRev
    {

    }
}
