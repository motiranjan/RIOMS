using RIOMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIOMS.WebUI.Models
{
    public class DCBMiscRev
    {
        List<Receipt> receipts;
        public DCBMiscRev(List<Receipt> argReceipt,MiscRevenue miscRev)
        {
            receipts = argReceipt;
        }
        
    }

    public class DCBMiscRevViewModel
    {
        Village village;
        
        public DCBMiscRevViewModel(Village argVillage )
        {
            village = argVillage;
           
        }

      

        public String VillageName
        {
            get { return village.Name; }
            
        }
        
        public DemandMiscRevenue Demand
        {
            get { return new DemandMiscRevenue {
                Arrear=village.DemandMiscRevenues.Sum(m=>m.Arrear), 
                Current=village.DemandMiscRevenues.Sum(m=>m.Current)
            }; }
            
        }
        public IEnumerable<IFormDetailMiscRevenue> IFormDetailMiscRevenues
        {
            get
            {
                return  village.IFormDetailMiscRevenues;
            }
        }
        public CollectionMiscRevenue TotalCollection
        {
            get
            {
                return new CollectionMiscRevenue
                {
                    Current = IFormDetailMiscRevenues.Sum(i => i.Current).GetValueOrDefault(),
                    Arrear = IFormDetailMiscRevenues.Sum(i => i.Arrear).GetValueOrDefault(),
                    Interest = IFormDetailMiscRevenues.Sum(i => i.Interest).GetValueOrDefault()
                };
            }
        }
        public CollectionMiscRevenue TahCollection
        {
            get
            {
                return new CollectionMiscRevenue
                {
                    Current = village.VillageWiseTahCollectionMiscRevenues.Sum(i => i.Current).GetValueOrDefault(),
                    Arrear = village.VillageWiseTahCollectionMiscRevenues.Sum(i => i.Arrear).GetValueOrDefault(),
                    Interest = village.VillageWiseTahCollectionMiscRevenues.Sum(i => i.Interest).GetValueOrDefault()
                };
            }
        }
        public bool HasTahCollection
        {
            get
            {
                return village.VillageWiseTahCollectionMiscRevenues.Count > 0;
            }
        }
        public CollectionMiscRevenue TotalCollectionAfterMovement
        {
            get
            {
                return new CollectionMiscRevenue
                {
                    Current = TotalCollection.Current + ComeFromVilllage.Sum(c => c.Current).GetValueOrDefault() - GoToVillage.Sum(g => g.Current).GetValueOrDefault(),
                    Arrear = TotalCollection.Arrear + ComeFromVilllage.Sum(c => c.Arrear).GetValueOrDefault() - GoToVillage.Sum(g => g.Arrear).GetValueOrDefault(),
                    Interest = TotalCollection.Interest// + ComeFromVilllage.Sum(c => c.Interest).GetValueOrDefault() - GoToVillage.Sum(g => g.Interest).GetValueOrDefault()
                };
            }
        }
        public CollectionMiscRevenue TotalCollectionAfterTah
        {
            get
            {
                return new CollectionMiscRevenue
                {
                    Current = TotalCollectionAfterMovement.Current + TahCollection.Current,
                    Arrear = TotalCollectionAfterMovement.Arrear + TahCollection.Arrear,
                    Interest = TotalCollectionAfterMovement.Interest + TahCollection.Interest
                };
            }
        }
        public DemandMiscRevenue Balance
        {
            get
            {
                return new DemandMiscRevenue
                {
                    Current = Demand.Current - TotalCollectionAfterTah.Current,
                    Arrear = Demand.Arrear - TotalCollectionAfterTah.Arrear
                };
            }
        }
        public IEnumerable<CollectionMovementMiscRevenue> GoToVillage
        {
            get
            {
                return village.CollectionMovementMiscRevenuesTo;
            }
        }
        public IEnumerable<CollectionMovementMiscRevenue> ComeFromVilllage
        {
            get
            {
                return village.CollectionMovementMiscRevenuesFrom;
            }
        }
    }
}