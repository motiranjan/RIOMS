using RIOMS.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace RIOMS.WebUI.Models
{
    public class DCBViewModel
    {

        public DCBViewModel(Village village, ICollection<IForm> argiforms)
        {
            Village = village;
            iforms = argiforms;
            for (int i = 0; i < iforms.Count; i++)
            {
                var iform = iforms.ElementAt(i);
                if (iform.IFormDetailCesses.Count + iform.IFormDetailLandRevenues.Count + iform.IFormDetailWaterTaxes.Count > 0)
                {
                    if (iform.IFormDetailCesses.Count == 0)
                    {
                        iform.IFormDetailCesses.Add(new IFormDetailCess());
                    }
                    if (iform.IFormDetailLandRevenues.Count == 0)
                    {
                        iform.IFormDetailLandRevenues.Add(new IFormDetailLandRevenue());
                    }
                    if (iform.IFormDetailWaterTaxes.Count == 0)
                    {
                        iform.IFormDetailWaterTaxes.Add(new IFormDetailWaterTax());
                    }
                }
                else
                {
                    iforms.Remove(iform);
                    i--;
                }
            }



        }

        public DCBViewModel(Village village)
        {
            Village = village;
        }
       
       
       
        private ICollection<IForm> iforms;

        public ICollection<IForm> IForms
        {
            get { return iforms; }

        }

        public Village Village { get; set; }


        public DemandCess ActualDemandCess
        {
            get
            {
                return new DemandCess
                {
                    MoreThanThree = Village.DemandCesses.Sum(a => a.MoreThanThree),
                    Third = Village.DemandCesses.Sum(a => a.Third),
                    Second = Village.DemandCesses.Sum(a => a.Second),
                    Previous = Village.DemandCesses.Sum(a => a.Previous),
                    Current = Village.DemandCesses.Sum(a => a.Current),
                    Advance = Village.DemandCesses.Sum(a => a.Advance)
                };
            }
        }
        public DemandLandRevenue ActualDemandLandRevenue
        {
            get
            {
                if (Village.DemandLandRevenues.Count > 0)
                {

                    return new DemandLandRevenue
                    {
                        MoreThanThree = Village.DemandLandRevenues.Sum(a => a.MoreThanThree),
                        Third = Village.DemandLandRevenues.Sum(a => a.Third),
                        Second = Village.DemandLandRevenues.Sum(a => a.Second),
                        Previous = Village.DemandLandRevenues.Sum(a => a.Previous),
                        Current = Village.DemandLandRevenues.Sum(a => a.Current),
                        Advance = Village.DemandLandRevenues.Sum(a => a.Advance)
                    };
                }
                else
                {
                    return new DemandLandRevenue();
                }
            }
        }
        public PartOneRev ActualDemandWaterTax
        {
            get
            {
                if (Village.DemandWaterTaxes.Count > 0)
                {

                    return new DemandWaterTax
                    {
                        MoreThanThree = Village.DemandWaterTaxes.Sum(a => a.MoreThanThree),
                        Third = Village.DemandWaterTaxes.Sum(a => a.Third),
                        Second = Village.DemandWaterTaxes.Sum(a => a.Second),
                        Previous = Village.DemandWaterTaxes.Sum(a => a.Previous),
                        Current = Village.DemandWaterTaxes.Sum(a => a.Current),
                        Advance = Village.DemandWaterTaxes.Sum(a => a.Advance)
                    };
                }
                else
                {
                    return new DemandWaterTax();
                }
            }
        }

        #region Demand

        public PartOneRev DemandCess
        {
            get
            {
                return Village.VillageWiseDemandCesses.FirstOrDefault();
            }
        }
        public PartOneRev DemandLandRevenue
        {
            get
            {
                return Village.VillageWiseDemandLandRevenues.FirstOrDefault();
            }
        }
        public PartOneRev DemandWaterTax
        {
            get
            {
                if (Village.DemandWaterTaxes.Count > 0)
                {

                    return Village.VillageWiseDemandWaterTaxes.FirstOrDefault();
                }
                else
                {
                    return new DemandWaterTax();
                }
            }
        }

        public PartOneRev DemandPartOneRev
        {
            get
            {
                return DemandCess + DemandLandRevenue + DemandWaterTax;
            }
        }
        #endregion

        #region Increase In Demand 
        public PartOneRev IncreaseInDemandCess
        {
            get
            {
                return Village.IncreaseInDemandCesses.FirstOrDefault() ?? new PartOneRev()  ;
            }
        }
        public PartOneRev IncreaseInDemandLandRevenue
        {
            get
            {
                return Village.IncreaseInDemandLandrevenues.FirstOrDefault() ?? new PartOneRev();

            }
        }
        public PartOneRev IncreaseInDemandPartOneRev
        {
            get
            {
                return IncreaseInDemandCess + IncreaseInDemandLandRevenue;
            }
        }
        #endregion

        #region Demand After Increase
        public PartOneRev DemandAfterIncreaseLandRevenue
        {
            get
            {
                return DemandLandRevenue + IncreaseInDemandLandRevenue;
            }
        }
        public PartOneRev DemandAfterIncreaseCess
        {
            get
            {
                return DemandCess + IncreaseInDemandCess;
            }
        }
        public PartOneRev DemandAfterIncreaseWaterTax
        {
            get
            {
                return DemandWaterTax;
            }
        }
        public PartOneRev DemandAfterIncreasePartOneRev
        {
            get
            {
                return DemandAfterIncreaseLandRevenue + DemandAfterIncreaseCess+DemandAfterIncreaseWaterTax;
            }
        }
        #endregion

        #region Advance Adjustment
        public PartOneRev AdvanceAdjustmentCess
        {
            get
            {
                return Village.AdvanceAdjustmentCesses.Sum();
            }
        }
        public PartOneRev AdvanceAdjustmentWaterTax
        {
            get
            {
                return Village.AdvanceAdjustmentWaterTaxes.Sum();
            }
        }
        public PartOneRev AdvanceAdjustmentLandRevenue
        {
            get
            {
                return Village.AdvanceAdjustmentLandRevenues.Sum();
            }
        }

        public PartOneRev AdvanceAdjustmentPartOneRev
        {
            get
            {
                return AdvanceAdjustmentCess + AdvanceAdjustmentLandRevenue + AdvanceAdjustmentWaterTax;
            }
        }
        #endregion

        #region Demand After Adjustment
        public PartOneRev NetDemandCess
        {
            get
            {
                return DemandAfterIncreaseCess - AdvanceAdjustmentCess;
            }
        }

        public PartOneRev NetDemandWaterTax
        {
            get
            {

                return DemandWaterTax - AdvanceAdjustmentWaterTax;
            }

        }

        public PartOneRev NetDemandLandRevenue
        {
            get
            {
                return DemandAfterIncreaseLandRevenue - AdvanceAdjustmentLandRevenue;
            }


        }
        #endregion

        #region Total Collection
        public CollectionPartOneRev TotalCollectionCess
        {
            get
            {
                return new CollectionPartOneRev
                {
                    MoreThanThree = Village.IFormDetailCesses.Sum(c => c.MoreThanThree),
                    Third = Village.IFormDetailCesses.Sum(c => c.Third),
                    Second = Village.IFormDetailCesses.Sum(c => c.Second),
                    Previous = Village.IFormDetailCesses.Sum(c => c.Previous),
                    Current = Village.IFormDetailCesses.Sum(c => c.Current)

                };
            }
        }
        public CollectionPartOneRev TotalCollectionWaterTax
        {
            get
            {
                return new CollectionPartOneRev
                {
                    MoreThanThree = Village.IFormDetailWaterTaxes.Sum(c => c.MoreThanThree),
                    Third = Village.IFormDetailWaterTaxes.Sum(c => c.Third),
                    Second = Village.IFormDetailWaterTaxes.Sum(c => c.Second),
                    Previous = Village.IFormDetailWaterTaxes.Sum(c => c.Previous),
                    Current = Village.IFormDetailWaterTaxes.Sum(c => c.Current)

                };
            }
        }
        public CollectionPartOneRev TotalCollectionLandRevenue
        {
            get
            {
                return new CollectionPartOneRev
                {
                    MoreThanThree = Village.IFormDetailLandRevenues.Sum(c => c.MoreThanThree),
                    Third = Village.IFormDetailLandRevenues.Sum(c => c.Third),
                    Second = Village.IFormDetailLandRevenues.Sum(c => c.Second),
                    Previous = Village.IFormDetailLandRevenues.Sum(c => c.Previous),
                    Current = Village.IFormDetailLandRevenues.Sum(c => c.Current)

                };
            }
        }
        #endregion

        #region Collection Movement
        public ICollection<CollectionMovementCess> ComeFromVillagesCess
        {
            get { return Village.CollectionMovementCessesFrom; }

        }
        public ICollection<CollectionMovementCess> GoToVillagesCess
        {
            get { return Village.CollectionMovementCessesTo; }

        }
        #endregion

        #region Tahasil Collection
        public PartOneRev TahCollectionCess
        {
            get
            {

                return Village.TahCollectionCesses.Sum();

            }
        }
        public PartOneRev TahCollectionWaterTax
        {
            get
            {

                return Village.TahCollectionWaterTaxes.Sum();

            }
        }
        public bool HasTahCollection
        {
            get
            {
                return TahCollectionCess.Total + TahCollectionLanadRevenue.Total + TahCollectionWaterTax.Total > 0;
            }
        }
        public PartOneRev TahCollectionLanadRevenue
        {
            get
            {
                return Village.TahCollectionLandRevenues.Sum();
            }
        }
        #endregion

        #region Total Collection After Movement
        public CollectionPartOneRev TotalCollectionWaterTaxAfterMovement
        {
            get
            {
                return TotalCollectionWaterTax;
            }
        }
        public CollectionPartOneRev TotalCollectionLandRevenueAfterMovement
        {
            get
            {
                return TotalCollectionLandRevenue;
            }
        }
        public PartOneRev TotalCollectionCessAfterMovement
        {
            get
            {
                return TotalCollectionCess + ComeFromVillagesCess.Sum() - GoToVillagesCess.Sum();
            }
        }
        #endregion

        #region Total collection after Tahasil collection
        public PartOneRev TotalCollectionCessAfterTah
        {
            get
            {
                return TotalCollectionCess + TahCollectionCess;
            }
        }
        public PartOneRev TotalCollectionWaterTaxAfterTah
        {
            get
            {
                return TotalCollectionWaterTax + TahCollectionWaterTax;
            }
        }
        public PartOneRev TotalCollectionLandRevenueAfterTah
        {
            get
            {
                return TotalCollectionLandRevenue + TahCollectionLanadRevenue;
            }
        }
        #endregion

        #region Advance Collection
        public PartOneRev AdvanceCollectionCess
        {
            get
            {
                return new PartOneRev();//Village.AdvanceCollectionCesses.Sum();
            }
        }
        public PartOneRev AdvanceCollectionWaterTax
        {
            get
            {
                return Village.AdvanceCollectionWaterTaxes.Sum();
            }
        }

        public PartOneRev AdvanceCollectionLandRevenue
        {
            get
            {
                return Village.AdvanceCollectionLandRevenues.Sum();
            }
        }
        #endregion

        #region Net Collection after Advance collection
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
        public PartOneRev NetCollectionPartOneRev
        {
            get
            {
                return NetCollectionCess + NetCollectionLandRevenue + NetCollectionWaterTax;

            }
        }
        #endregion

        #region Net collection with adv adj
        public PartOneRev NetCollectionWithAdvAdjCess
        {
            get
            {
                return NetCollectionCess+AdvanceAdjustmentCess;
            }
        }
        public PartOneRev NetCollectionWithAdvAdjLandRevenue
        {
            get
            {
                return NetCollectionLandRevenue + AdvanceAdjustmentLandRevenue;
            }
        }
        public PartOneRev NetCollectionWithAdvAdjWaterTax
        {
            get
            {
                return NetCollectionWaterTax + AdvanceAdjustmentWaterTax;
            }
        }
        public PartOneRev NetCollectionWithAdvAdjPartOneRev
        {
            get
            {
                return NetCollectionWithAdvAdjLandRevenue + NetCollectionWithAdvAdjCess + NetCollectionWithAdvAdjWaterTax;

            }
        }
        #endregion

        #region Balance

        public PartOneRev BalanceCess
        {
            get
            {
                return NetDemandCess - NetCollectionCess;
            }
        }
        public PartOneRev BalanceWaterTax
        {
            get
            {
                return NetDemandWaterTax - NetCollectionWaterTax;
            }
        }
        public PartOneRev BalanceLandRevenue
        {
            get
            {
                return NetDemandLandRevenue - NetCollectionLandRevenue;
            }
        }
        public PartOneRev BalancePartOneRev
        {
            get
            {
                return BalanceCess + BalanceLandRevenue + BalanceWaterTax;



            }
        }
        #endregion
        //public CollectionPartOneRev TotalCollectionCessAfterMovement
        //{
        //    get
        //    {
        //        return new CollectionCess
        //        {
        //            MoreThanThree = Village.IFormDetailCesses.Sum(c => c.MoreThanThree) + ComeFromVillagesCess.Sum(m => m.MoreThanThree) - GoToVillagesCess.Sum(m => m.MoreThanThree),
        //            Third = Village.IFormDetailCesses.Sum(c => c.Third) + ComeFromVillagesCess.Sum(m => m.Third) - GoToVillagesCess.Sum(m => m.Third),
        //            Second = Village.IFormDetailCesses.Sum(c => c.Second) + ComeFromVillagesCess.Sum(m => m.Second) - GoToVillagesCess.Sum(m => m.Second),
        //            Previous = Village.IFormDetailCesses.Sum(c => c.Previous) + ComeFromVillagesCess.Sum(m => m.Previous) - GoToVillagesCess.Sum(m => m.Previous),
        //            Current = Village.IFormDetailCesses.Sum(c => c.Current) + ComeFromVillagesCess.Sum(m => m.Current) - GoToVillagesCess.Sum(m => m.Current),

        //        };
        //    }
        //}









    }

}
