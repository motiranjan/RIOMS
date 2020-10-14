using RIOMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIOMS.WebUI.Models
{
    public class DCBXVI2ViewModel:DCBMiscRevViewModel
    {
        Village village;
        public DCBXVI2ViewModel(Village argvillage)
            : base(argvillage)
        {
            village = argvillage;
        }
        public decimal CollectionIntrestCess
        {
            get { return (village.IFormDetailCesses.Sum(c => c.InterestTotal).GetValueOrDefault() + village.CollectionMovementCessesTo.Sum(m => m.IntrestTotal).GetValueOrDefault())+village.VillageWiseTahCollectionCesses.Sum(c=>c.InterestTotal).GetValueOrDefault() - village.CollectionMovementCessesFrom.Sum(m => m.IntrestTotal).GetValueOrDefault(); }
        }
        public decimal CollectionIntrestLR
        {
            get { return (village.IFormDetailLandRevenues.Sum(c => c.InterestTotal).GetValueOrDefault());  }
        }
         public decimal CollectionIntrestWaterTax
        {
            get { return (village.IFormDetailWaterTaxes.Sum(c => c.InterestTotal).GetValueOrDefault());  }
        }
        
        public decimal CollectionDF
        {
            get { return village.IFormDetailOthers.Where(o=>o.type=="DF").Sum(o => o.Amount).GetValueOrDefault() + village.IFormDetailOLRs.Sum(o => o.DemarcationFee).GetValueOrDefault(); }
           
        }
        public decimal CollectionLPB
        {
            get { return village.IFormDetailOthers.Where(o => o.type == "LPB").Sum(o => o.Amount).GetValueOrDefault(); } 

        }
        public decimal CollectionProcessingFee
        {
            get { return village.IFormDetailOPDRs.Sum(o => o.Amount).GetValueOrDefault(); }

        }
        public decimal CollectionPremium
        {
            get { return village.IFormDetailOLRs.Sum(ol => ol.Premium).GetValueOrDefault(); }
        }
    }
}