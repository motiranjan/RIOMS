using RIOMS.Domain;
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
                    MoreThanThree = iforms.Sum(i => i.IFormDetailCesses.Sum(c => c.MoreThanThree)).GetValueOrDefault(),
                    Third = iforms.Sum(i => i.IFormDetailCesses.Sum(c => c.Third)).GetValueOrDefault(),
                    Second = iforms.Sum(i => i.IFormDetailCesses.Sum(c => c.Second)).GetValueOrDefault(),
                    Previous = iforms.Sum(i => i.IFormDetailCesses.Sum(c => c.Previous)).GetValueOrDefault(),
                    Current = iforms.Sum(i => i.IFormDetailCesses.Sum(c => c.Current)).GetValueOrDefault(),
                    InterestTotal = iforms.Sum(i => i.IFormDetailCesses.Sum(c => c.InterestTotal)).GetValueOrDefault()

                };
            }
        }
        public CollectionWaterTax TotalCollectionWaterTax
        {
            get
            {
                return new CollectionWaterTax
                {
                    MoreThanThree = iforms.Sum(i => i.IFormDetailWaterTaxes.Sum(c => c.MoreThanThree)).GetValueOrDefault(),
                    Third = iforms.Sum(i => i.IFormDetailWaterTaxes.Sum(c => c.Third)).GetValueOrDefault(),
                    Second = iforms.Sum(i => i.IFormDetailWaterTaxes.Sum(c => c.Second)).GetValueOrDefault(),
                    Previous = iforms.Sum(i => i.IFormDetailWaterTaxes.Sum(c => c.Previous)).GetValueOrDefault(),
                    Current = iforms.Sum(i => i.IFormDetailWaterTaxes.Sum(c => c.Current)).GetValueOrDefault(),
                    InterestTotal = iforms.Sum(i => i.IFormDetailWaterTaxes.Sum(c => c.InterestTotal)).GetValueOrDefault()
                };
            }
        }
        public CollectionLandRevenue TotalCollectionLandRevenue
        {
            get
            {
                return new CollectionLandRevenue
                {
                    MoreThanThree = iforms.Sum(i => i.IFormDetailLandRevenues.Sum(c => c.MoreThanThree)).GetValueOrDefault(),
                    Third = iforms.Sum(i => i.IFormDetailLandRevenues.Sum(c => c.Third)).GetValueOrDefault(),
                    Second = iforms.Sum(i => i.IFormDetailLandRevenues.Sum(c => c.Second)).GetValueOrDefault(),
                    Previous = iforms.Sum(i => i.IFormDetailLandRevenues.Sum(c => c.Previous)).GetValueOrDefault(),
                    Current = iforms.Sum(i => i.IFormDetailLandRevenues.Sum(c => c.Current)).GetValueOrDefault(),
                    InterestTotal = iforms.Sum(i => i.IFormDetailLandRevenues.Sum(c => c.InterestTotal)).GetValueOrDefault()
                };
            }
        }
        public CollectionOther TotalCollectionOther
        {
            get
            {
                return new CollectionOther
                {
                    Amount = iforms.Sum(i => i.IFormDetailOthers.Sum(c => c.Amount)).GetValueOrDefault()
                   
                };
            }
        }
        public CollectionOLR TotalCollectionOLR
        {
            get
            {
                return new CollectionOLR
                {
                    DemarcationFee = iforms.Sum(i => i.IFormDetailOLRs.Sum(c => c.DemarcationFee)).GetValueOrDefault()

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
                    MoreThanThree = Village.IFormDetailCesses.Sum(c => c.MoreThanThree).GetValueOrDefault() + ComeFromVillagesCess.Sum(m => m.MoreThanThree).GetValueOrDefault() - GoToVillagesCess.Sum(m => m.MoreThanThree).GetValueOrDefault(),
                    Third = Village.IFormDetailCesses.Sum(c => c.Third).GetValueOrDefault() + ComeFromVillagesCess.Sum(m => m.Third).GetValueOrDefault() - GoToVillagesCess.Sum(m => m.Third).GetValueOrDefault(),
                    Second = Village.IFormDetailCesses.Sum(c => c.Second).GetValueOrDefault() + ComeFromVillagesCess.Sum(m => m.Second).GetValueOrDefault() - GoToVillagesCess.Sum(m => m.Second).GetValueOrDefault(),
                    Previous = Village.IFormDetailCesses.Sum(c => c.Previous).GetValueOrDefault() + ComeFromVillagesCess.Sum(m => m.Previous).GetValueOrDefault() - GoToVillagesCess.Sum(m => m.Previous).GetValueOrDefault(),
                    Current = Village.IFormDetailCesses.Sum(c => c.Current).GetValueOrDefault() + ComeFromVillagesCess.Sum(m => m.Current).GetValueOrDefault() - GoToVillagesCess.Sum(m => m.Current).GetValueOrDefault(),
                    InterestTotal = Village.IFormDetailCesses.Sum(c => c.InterestTotal).GetValueOrDefault() + ComeFromVillagesCess.Sum(m => m.IntrestTotal).GetValueOrDefault() - GoToVillagesCess.Sum(m => m.IntrestTotal).GetValueOrDefault(),

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
                    MoreThanThree = TotalCollectionCessAfterMovement.MoreThanThree + TahCollectionCess.MoreThanThree.GetValueOrDefault(),
                    Third = TotalCollectionCessAfterMovement.Third + TahCollectionCess.Third.GetValueOrDefault(),
                    Second = TotalCollectionCessAfterMovement.Second + TahCollectionCess.Second.GetValueOrDefault(),
                    Previous = TotalCollectionCessAfterMovement.Previous + TahCollectionCess.Previous.GetValueOrDefault(),
                    Current = TotalCollectionCessAfterMovement.Current + TahCollectionCess.Current.GetValueOrDefault(),
                    InterestTotal = TotalCollectionCessAfterMovement.InterestTotal + TahCollectionCess.InterestTotal.GetValueOrDefault()
                };
            }
        }
        public CollectionWaterTax TotalCollectionWaterTaxAfterTah
        {
            get
            {
                return new CollectionWaterTax
                {
                    MoreThanThree = TotalCollectionWaterTaxAfterMovement.MoreThanThree + TahCollectionWaterTax.MoreThanThree.GetValueOrDefault(),
                    Third = TotalCollectionWaterTaxAfterMovement.Third + TahCollectionWaterTax.Third.GetValueOrDefault(),
                    Second = TotalCollectionWaterTaxAfterMovement.Second + TahCollectionWaterTax.Second.GetValueOrDefault(),
                    Previous = TotalCollectionWaterTaxAfterMovement.Previous + TahCollectionWaterTax.Previous.GetValueOrDefault(),
                    Current = TotalCollectionWaterTaxAfterMovement.Current + TahCollectionWaterTax.Current.GetValueOrDefault(),

                };
            }
        }
        public CollectionLandRevenue TotalCollectionLandRevenueAfterTah
        {
            get
            {
                return new CollectionLandRevenue
                {
                    MoreThanThree = TotalCollectionLandRevenueAfterMovement.MoreThanThree + TahCollectionLanadRevenue.MoreThanThree.GetValueOrDefault(),
                    Third = TotalCollectionLandRevenueAfterMovement.Third + TahCollectionLanadRevenue.Third.GetValueOrDefault(),
                    Second = TotalCollectionLandRevenueAfterMovement.Second + TahCollectionLanadRevenue.Second.GetValueOrDefault(),
                    Previous = TotalCollectionLandRevenueAfterMovement.Previous + TahCollectionLanadRevenue.Previous.GetValueOrDefault(),
                    Current = TotalCollectionLandRevenueAfterMovement.Current + TahCollectionLanadRevenue.Current.GetValueOrDefault(),

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
                    MoreThanThree = TotalCollectionCessAfterTah.MoreThanThree - AdvanceCollectionCess.MoreThanThree.GetValueOrDefault(),
                    Third = TotalCollectionCessAfterTah.Third - AdvanceCollectionCess.Third.GetValueOrDefault(),
                    Second = TotalCollectionCessAfterTah.Second - AdvanceCollectionCess.Second.GetValueOrDefault(),
                    Previous = TotalCollectionCessAfterTah.Previous - AdvanceCollectionCess.Previous.GetValueOrDefault(),
                    Current = TotalCollectionCessAfterTah.Current - AdvanceCollectionCess.Current.GetValueOrDefault(),
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
                    MoreThanThree = TotalCollectionLandRevenueAfterTah.MoreThanThree - AdvanceCollectionLandRevenue.MoreThanThree.GetValueOrDefault(),
                    Third = TotalCollectionLandRevenueAfterTah.Third - AdvanceCollectionLandRevenue.Third.GetValueOrDefault(),
                    Second = TotalCollectionLandRevenueAfterTah.Second - AdvanceCollectionLandRevenue.Second.GetValueOrDefault(),
                    Previous = TotalCollectionLandRevenueAfterTah.Previous - AdvanceCollectionLandRevenue.Previous.GetValueOrDefault(),
                    Current = TotalCollectionLandRevenueAfterTah.Current - AdvanceCollectionLandRevenue.Current.GetValueOrDefault(),


                };
            }
        }
        public CollectionWaterTax NetCollectionWaterTax
        {
            get
            {
                return new CollectionWaterTax
                {
                    MoreThanThree = TotalCollectionWaterTaxAfterTah.MoreThanThree - AdvanceCollectionWaterTax.MoreThanThree.GetValueOrDefault(),
                    Third = TotalCollectionWaterTaxAfterTah.Third - AdvanceCollectionWaterTax.Third.GetValueOrDefault(),
                    Second = TotalCollectionWaterTaxAfterTah.Second - AdvanceCollectionWaterTax.Second.GetValueOrDefault(),
                    Previous = TotalCollectionWaterTaxAfterTah.Previous - AdvanceCollectionWaterTax.Previous.GetValueOrDefault(),
                    Current = TotalCollectionWaterTaxAfterTah.Current - AdvanceCollectionWaterTax.Current.GetValueOrDefault(),


                };
            }
        }
    }
}