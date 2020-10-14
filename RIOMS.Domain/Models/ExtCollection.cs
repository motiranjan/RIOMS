using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RIOMS.Domain.Models
{
   public partial class VillageWiseTahCollectionCess
    {
      

        public decimal Total
        {
            get { return MoreThanThree.GetValueOrDefault()+Third.GetValueOrDefault()+Second.GetValueOrDefault()+Previous.GetValueOrDefault()+Current.GetValueOrDefault() ; }
           }
        
    }
   public partial class VillageWiseTahCollectionLandRevenue
   {


       public decimal Total
       {
           get { return MoreThanThree.GetValueOrDefault() + Third.GetValueOrDefault() + Second.GetValueOrDefault() + Previous.GetValueOrDefault() + Current.GetValueOrDefault(); }
       }

   }
   public partial class VillageWiseTahCollectionWaterTax
   {


       public decimal Total
       {
           get { return MoreThanThree.GetValueOrDefault() + Third.GetValueOrDefault() + Second.GetValueOrDefault() + Previous.GetValueOrDefault() + Current.GetValueOrDefault(); }
       }

   }
}
