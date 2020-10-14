using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RIOMS.Domain.Models
{
    public partial class AdvanceCollectionCess
    {
       
        public decimal Total
        {
            get { return MoreThanThree.GetValueOrDefault() + Third.GetValueOrDefault() + Second.GetValueOrDefault() + Previous.GetValueOrDefault() + Current.GetValueOrDefault(); }
           
        }
        
    }
    public partial class AdvanceCollectionWaterTax
    {

        public decimal Total
        {
            get { return MoreThanThree.GetValueOrDefault() + Third.GetValueOrDefault() + Second.GetValueOrDefault() + Previous.GetValueOrDefault() + Current.GetValueOrDefault(); }

        }

    }
    public partial class AdvanceCollectionLandRevenue
    {

        public decimal Total
        {
            get { return MoreThanThree.GetValueOrDefault() + Third.GetValueOrDefault() + Second.GetValueOrDefault() + Previous.GetValueOrDefault() + Current.GetValueOrDefault(); }

        }

    }
}
