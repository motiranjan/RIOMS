using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RIOMS.Domain
{
     
    public partial class IFormDetailCess
    {
       

        public decimal Total
        {
            get
            {


                return MoreThanThree.GetValueOrDefault() + Third.GetValueOrDefault() + Second.GetValueOrDefault() + Previous.GetValueOrDefault() + Current.GetValueOrDefault();

            }
        }

    }
    public partial class IFormDetailLandRevenue
    {
        public decimal Total
        {
            get
            {


                return MoreThanThree.GetValueOrDefault() + Third.GetValueOrDefault() + Second.GetValueOrDefault() + Previous.GetValueOrDefault() + Current.GetValueOrDefault();

            }
        }

    }
    public partial class IFormDetailWaterTax
    {
        public decimal Total
        {
            get
            {


                return MoreThanThree.GetValueOrDefault() + Third.GetValueOrDefault() + Second.GetValueOrDefault() + Previous.GetValueOrDefault() + Current.GetValueOrDefault();

            }
        }

    }


}
