using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RIOMS.Domain
{
   public class CollectionPartOneRev : PartOneRev
    {
       public decimal InterestTotal { get; set; }
    }
    public partial class CollectionCess
    {
        public decimal Advance { get; set; }
        public decimal Total
        {
            get
            {
                return MoreThanThree + Third + Second + Previous + Current;
            }

        }
        public decimal Arrear
        {
            get
            {
                return MoreThanThree + Third + Second + Previous;
            }

        }
    }
    public partial class CollectionWaterTax 
    {
        public decimal Total
        {
            get
            {
                return MoreThanThree + Third + Second + Previous + Current;
            }

        }
        public decimal Arrear
        {
            get
            {
                return MoreThanThree + Third + Second + Previous;
            }

        }
        public decimal Advance { get; set; }
    }
    public partial class CollectionLandRevenue 
    {
        public decimal Advance { get; set; }
        public decimal Total
        {
            get
            {
                return MoreThanThree + Third + Second + Previous + Current;
            }

        }
        public decimal Arrear
        {
            get
            {
                return MoreThanThree + Third + Second + Previous;
            }

        }
    }
}
