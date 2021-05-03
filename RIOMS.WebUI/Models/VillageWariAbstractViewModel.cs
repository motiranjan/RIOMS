using RIOMS.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace RIOMS.WebUI.Models
{
    public class VillageWariAbstractViewModel
    {

        public VillageWariAbstractViewModel(IEnumerable<IForm> argIforms, Village argVillage)
        {
            iforms = argIforms;
            village = argVillage;
        }

        Village village;
        public Village Village { get { return village; } }
        IEnumerable<IForm> iforms;
        public IEnumerable<IForm> IForms
        {
            get { return iforms; }

        }
        public PartOneRev TotalCollectionCess
        {
            get
            {
                return iforms.Select(i => i.IFormDetailCesses.Sum()).Sum();

            }
        }
        public PartOneRev TotalCollectionWaterTax
        {
            get
            {
                return iforms.Select(i => i.IFormDetailWaterTaxes.Sum()).Sum();
            }
        }
        public PartOneRev TotalCollectionLandRevenue
        {
            get
            {
                return iforms.Select(i => i.IFormDetailLandRevenues.Sum()).Sum();
            }
        }
        public CollectionMiscRevenue TotalCollectionMiscRevenue
        {
            get
            {
                return new CollectionMiscRevenue
                {
                    Current = iforms.Sum(i => i.IFormDetailMiscRevenues.Sum(c => c.Current)).Value,
                    Arrear = iforms.Sum(i => i.IFormDetailMiscRevenues.Sum(c => c.Arrear)).Value,
                    Interest = iforms.Sum(i => i.IFormDetailMiscRevenues.Sum(c => c.Interest)).Value,
                };
            }
        }
        public CollectionOther TotalCollectionOther
        {
            get
            {
                return new CollectionOther
                {
                    Amount = iforms.Sum(i => i.IFormDetailOthers.Sum(c => c.Amount))

                };
            }
        }
        public CollectionOLR TotalCollectionOLR
        {
            get
            {
                return new CollectionOLR
                {
                    DemarcationFee = iforms.Sum(i => i.IFormDetailOLRs.Sum(c => c.DemarcationFee)),
                    Premium= iforms.Sum(i => i.IFormDetailOLRs.Sum(c => c.Premium))

                };
            }
        }
        public IEnumerable<CollectionMovementCess> ComeFromVillagesCesses
        {
            get { return Village.CollectionMovementCessesFrom; }

        }
        public IEnumerable<CollectionMovementCess> GoToVillagesCesses
        {
            get { return Village.CollectionMovementCessesTo; }

        }
        public PartOneRev TotalCollectionCessAfterMovement
        {
            get
            {
                return TotalCollectionCess + ComeFromVillagesCesses.Sum()-GoToVillagesCesses.Sum();
            }
        }
        public PartOneRev AdvanceCollectionCess
        {
            get
            {
                return village.AdvanceCollectionCesses.Sum();
            }
        }
        public PartOneRev AdvanceCollectionWaterTax
        {
            get
            {
                return  village.AdvanceCollectionWaterTaxes.Sum();
            }
        }

        public PartOneRev AdvanceCollectionLandRevenue
        {
            get
            {
                return village.AdvanceCollectionLandRevenues.Sum();
            }
        }
        public PartOneRev TahCollectionCess
        {
            get
            {
                return village.TahCollectionCesses.Sum();
            }
        }
        public PartOneRev TahCollectionWaterTax
        {
            get
            {
                return village.TahCollectionWaterTaxes.Sum();
            }
        }
        public bool HasTahCollection
        {
            get
            {
                return (Village.TahReceipts.Count > 0);
            }
        }
        public PartOneRev TahCollectionLanadRevenue
        {
            get
            {
                return village.TahCollectionLandRevenues.Sum();
            }
        }
        public PartOneRev TotalCollectionCessAfterTah
        {
            get
            {
                return TotalCollectionCessAfterMovement + TahCollectionCess;
            }
        }
        public PartOneRev TotalCollectionWaterTaxAfterTah
        {
            get
            {
                return TotalCollectionWaterTaxAfterMovement + TahCollectionWaterTax;
            }
        }
        public PartOneRev TotalCollectionLandRevenueAfterTah
        {
            get
            {
                return TotalCollectionLandRevenueAfterMovement + TahCollectionLanadRevenue;
            }
        }

        public PartOneRev TotalCollectionWaterTaxAfterMovement
        {
            get
            {
                return TotalCollectionWaterTax;
            }
        }
        public PartOneRev TotalCollectionLandRevenueAfterMovement
        {
            get
            {
                return TotalCollectionLandRevenue;
            }
        }


        public PartOneRev NetCollectionCess
        {
            get
            {
                return TotalCollectionCessAfterTah - AdvanceCollectionCess;
            }
        }
        public PartOneRev NetCollectionLandRevenue
        {
            get
            {
                return TotalCollectionLandRevenueAfterTah - AdvanceCollectionLandRevenue;
            }
        }
        public PartOneRev NetCollectionWaterTax
        {
            get
            {
                return TotalCollectionWaterTaxAfterTah - AdvanceCollectionWaterTax;
            }
        }
    }
}