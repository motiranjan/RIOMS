using RIOMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIOMS.WebUI.Models
{
    public class VillageWariAbstractViewModel
    {

        public VillageWariAbstractViewModel(IEnumerable<IForm> argIforms,Village argVillage)
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
        public CollectionCess TotalCollectionCess
        {
            get
            {
                return new CollectionCess
                {
                    MoreThanThree = iforms.Sum(i => i.IFormDetailCesses.Sum(c => c.MoreThanThree)),
                    Third = iforms.Sum(i => i.IFormDetailCesses.Sum(c => c.Third)),
                    Second = iforms.Sum(i => i.IFormDetailCesses.Sum(c => c.Second)),
                    Previous = iforms.Sum(i => i.IFormDetailCesses.Sum(c => c.Previous)),
                    Current = iforms.Sum(i => i.IFormDetailCesses.Sum(c => c.Current)),
                    InterestTotal = iforms.Sum(i => i.IFormDetailCesses.Sum(c => c.InterestTotal))

                };
            }
        }
        public CollectionWaterTax TotalCollectionWaterTax
        {
            get
            {
                return new CollectionWaterTax
                {
                    MoreThanThree = iforms.Sum(i => i.IFormDetailWaterTaxes.Sum(c => c.MoreThanThree)),
                    Third = iforms.Sum(i => i.IFormDetailWaterTaxes.Sum(c => c.Third)),
                    Second = iforms.Sum(i => i.IFormDetailWaterTaxes.Sum(c => c.Second)),
                    Previous = iforms.Sum(i => i.IFormDetailWaterTaxes.Sum(c => c.Previous)),
                    Current = iforms.Sum(i => i.IFormDetailWaterTaxes.Sum(c => c.Current)),
                    InterestTotal = iforms.Sum(i => i.IFormDetailWaterTaxes.Sum(c => c.InterestTotal))
                };
            }
        }
        public CollectionLandRevenue TotalCollectionLandRevenue
        {
            get
            {
                return new CollectionLandRevenue
                {
                    MoreThanThree = iforms.Sum(i => i.IFormDetailLandRevenues.Sum(c => c.MoreThanThree)),
                    Third = iforms.Sum(i => i.IFormDetailLandRevenues.Sum(c => c.Third)),
                    Second = iforms.Sum(i => i.IFormDetailLandRevenues.Sum(c => c.Second)),
                    Previous = iforms.Sum(i => i.IFormDetailLandRevenues.Sum(c => c.Previous)),
                    Current = iforms.Sum(i => i.IFormDetailLandRevenues.Sum(c => c.Current)),
                    InterestTotal = iforms.Sum(i => i.IFormDetailLandRevenues.Sum(c => c.InterestTotal))
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
                    DemarcationFee = iforms.Sum(i => i.IFormDetailOLRs.Sum(c => c.DemarcationFee))

                };
            }
        }
        public IEnumerable<CollectionMovementCess> ComeFromVillagesCess
        {
            get { return Village.CollectionMovementCessesFrom; }

        }
        public IEnumerable<CollectionMovementCess> GoToVillagesCess
        {
            get { return Village.CollectionMovementCessesTo; }

        }
        public CollectionCess TotalCollectionCessAfterMovement
        {
            get
            {
                return new CollectionCess
                {
                    MoreThanThree = Village.IFormDetailCesses.Sum(c => c.MoreThanThree) + ComeFromVillagesCess.Sum(m => m.MoreThanThree) - GoToVillagesCess.Sum(m => m.MoreThanThree),
                    Third = Village.IFormDetailCesses.Sum(c => c.Third) + ComeFromVillagesCess.Sum(m => m.Third) - GoToVillagesCess.Sum(m => m.Third),
                    Second = Village.IFormDetailCesses.Sum(c => c.Second) + ComeFromVillagesCess.Sum(m => m.Second) - GoToVillagesCess.Sum(m => m.Second),
                    Previous = Village.IFormDetailCesses.Sum(c => c.Previous) + ComeFromVillagesCess.Sum(m => m.Previous) - GoToVillagesCess.Sum(m => m.Previous),
                    Current = Village.IFormDetailCesses.Sum(c => c.Current) + ComeFromVillagesCess.Sum(m => m.Current) - GoToVillagesCess.Sum(m => m.Current),
                    InterestTotal = Village.IFormDetailCesses.Sum(c => c.InterestTotal) + ComeFromVillagesCess.Sum(m => m.IntrestTotal) - GoToVillagesCess.Sum(m => m.IntrestTotal),

                };
            }
        }
        public AdvanceCollectionCess AdvanceCollectionCess
        {
            get
            {
                return new AdvanceCollectionCess
                {
                    MoreThanThree = Village.AdvanceCollectionCesses.Sum(a => a.MoreThanThree),
                    Third = Village.AdvanceCollectionCesses.Sum(a => a.Third),
                    Second = Village.AdvanceCollectionCesses.Sum(a => a.Second),
                    Previous = Village.AdvanceCollectionCesses.Sum(a => a.Previous),
                    Current = Village.AdvanceCollectionCesses.Sum(a => a.Current),
                };
            }
        }
        public AdvanceCollectionWaterTax AdvanceCollectionWaterTax
        {
            get
            {
                return new AdvanceCollectionWaterTax
                {
                    MoreThanThree = Village.AdvanceCollectionWaterTaxes.Sum(a => a.MoreThanThree),
                    Third = Village.AdvanceCollectionWaterTaxes.Sum(a => a.Third),
                    Second = Village.AdvanceCollectionWaterTaxes.Sum(a => a.Second),
                    Previous = Village.AdvanceCollectionWaterTaxes.Sum(a => a.Previous),
                    Current = Village.AdvanceCollectionWaterTaxes.Sum(a => a.Current),
                };
            }
        }

        public AdvanceCollectionLandRevenue AdvanceCollectionLandRevenue
        {
            get
            {
                return new AdvanceCollectionLandRevenue
                {
                    MoreThanThree = Village.AdvanceCollectionLandRevenues.Sum(a => a.MoreThanThree),
                    Third = Village.AdvanceCollectionLandRevenues.Sum(a => a.Third),
                    Second = Village.AdvanceCollectionLandRevenues.Sum(a => a.Second),
                    Previous = Village.AdvanceCollectionLandRevenues.Sum(a => a.Previous),
                    Current = Village.AdvanceCollectionLandRevenues.Sum(a => a.Current),
                };
            }
        }
        public VillageWiseTahCollectionCess TahCollectionCess
        {
            get
            {
                if (Village.VillageWiseTahCollectionCesses.Count > 0)
                {
                    return Village.VillageWiseTahCollectionCesses.ElementAt(0);
                }
                else
                {
                    return new VillageWiseTahCollectionCess();
                }
            }
        }
        public VillageWiseTahCollectionWaterTax TahCollectionWaterTax
        {
            get
            {
                if (Village.VillageWiseTahCollectionWaterTaxes.Count > 0)
                {
                    return Village.VillageWiseTahCollectionWaterTaxes.ElementAt(0);
                }
                else
                {
                    return new VillageWiseTahCollectionWaterTax();
                }
            }
        }
        public bool HasTahCollection
        {
            get
            {
                return (Village.VillageWiseTahCollectionLandRevenues.Count + Village.VillageWiseTahCollectionWaterTaxes.Count + Village.VillageWiseTahCollectionCesses.Count > 0);
            }
        }
        public VillageWiseTahCollectionLandRevenue TahCollectionLanadRevenue
        {
            get
            {
                if (Village.VillageWiseTahCollectionLandRevenues.Count > 0)
                {
                    return Village.VillageWiseTahCollectionLandRevenues.ElementAt(0);
                }
                else
                {
                    return new VillageWiseTahCollectionLandRevenue();
                }
            }
        }
        public CollectionCess TotalCollectionCessAfterTah
        {
            get
            {
                return new CollectionCess
                {
                    MoreThanThree = TotalCollectionCessAfterMovement.MoreThanThree + TahCollectionCess.MoreThanThree,
                    Third = TotalCollectionCessAfterMovement.Third + TahCollectionCess.Third,
                    Second = TotalCollectionCessAfterMovement.Second + TahCollectionCess.Second,
                    Previous = TotalCollectionCessAfterMovement.Previous + TahCollectionCess.Previous,
                    Current = TotalCollectionCessAfterMovement.Current + TahCollectionCess.Current,
                    InterestTotal = TotalCollectionCessAfterMovement.InterestTotal + TahCollectionCess.InterestTotal
                };
            }
        }
        public CollectionWaterTax TotalCollectionWaterTaxAfterTah
        {
            get
            {
                return new CollectionWaterTax
                {
                    MoreThanThree = TotalCollectionWaterTaxAfterMovement.MoreThanThree + TahCollectionWaterTax.MoreThanThree,
                    Third = TotalCollectionWaterTaxAfterMovement.Third + TahCollectionWaterTax.Third,
                    Second = TotalCollectionWaterTaxAfterMovement.Second + TahCollectionWaterTax.Second,
                    Previous = TotalCollectionWaterTaxAfterMovement.Previous + TahCollectionWaterTax.Previous,
                    Current = TotalCollectionWaterTaxAfterMovement.Current + TahCollectionWaterTax.Current,

                };
            }
        }
        public CollectionLandRevenue TotalCollectionLandRevenueAfterTah
        {
            get
            {
                return new CollectionLandRevenue
                {
                    MoreThanThree = TotalCollectionLandRevenueAfterMovement.MoreThanThree + TahCollectionLanadRevenue.MoreThanThree,
                    Third = TotalCollectionLandRevenueAfterMovement.Third + TahCollectionLanadRevenue.Third,
                    Second = TotalCollectionLandRevenueAfterMovement.Second + TahCollectionLanadRevenue.Second,
                    Previous = TotalCollectionLandRevenueAfterMovement.Previous + TahCollectionLanadRevenue.Previous,
                    Current = TotalCollectionLandRevenueAfterMovement.Current + TahCollectionLanadRevenue.Current,

                };
            }
        }

        public CollectionWaterTax TotalCollectionWaterTaxAfterMovement
        {
            get
            {
                return TotalCollectionWaterTax;
            }
        }
        public CollectionLandRevenue TotalCollectionLandRevenueAfterMovement
        {
            get
            {
                return TotalCollectionLandRevenue;
            }
        }


        public CollectionCess NetCollectionCess
        {
            get
            {
                return new CollectionCess
                {
                    MoreThanThree = TotalCollectionCessAfterTah.MoreThanThree - AdvanceCollectionCess.MoreThanThree,
                    Third = TotalCollectionCessAfterTah.Third - AdvanceCollectionCess.Third,
                    Second = TotalCollectionCessAfterTah.Second - AdvanceCollectionCess.Second,
                    Previous = TotalCollectionCessAfterTah.Previous - AdvanceCollectionCess.Previous,
                    Current = TotalCollectionCessAfterTah.Current - AdvanceCollectionCess.Current,
                    InterestTotal=TotalCollectionCessAfterTah.InterestTotal

                };
            }
        }
        public CollectionLandRevenue NetCollectionLandRevenue
        {
            get
            {
                return new CollectionLandRevenue
                {
                    MoreThanThree = TotalCollectionLandRevenueAfterTah.MoreThanThree - AdvanceCollectionLandRevenue.MoreThanThree,
                    Third = TotalCollectionLandRevenueAfterTah.Third - AdvanceCollectionLandRevenue.Third,
                    Second = TotalCollectionLandRevenueAfterTah.Second - AdvanceCollectionLandRevenue.Second,
                    Previous = TotalCollectionLandRevenueAfterTah.Previous - AdvanceCollectionLandRevenue.Previous,
                    Current = TotalCollectionLandRevenueAfterTah.Current - AdvanceCollectionLandRevenue.Current,


                };
            }
        }
        public CollectionWaterTax NetCollectionWaterTax
        {
            get
            {
                return new CollectionWaterTax
                {
                    MoreThanThree = TotalCollectionWaterTaxAfterTah.MoreThanThree - AdvanceCollectionWaterTax.MoreThanThree,
                    Third = TotalCollectionWaterTaxAfterTah.Third - AdvanceCollectionWaterTax.Third,
                    Second = TotalCollectionWaterTaxAfterTah.Second - AdvanceCollectionWaterTax.Second,
                    Previous = TotalCollectionWaterTaxAfterTah.Previous - AdvanceCollectionWaterTax.Previous,
                    Current = TotalCollectionWaterTaxAfterTah.Current - AdvanceCollectionWaterTax.Current,


                };
            }
        }
    }
}