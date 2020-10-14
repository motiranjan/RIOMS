using RIOMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIOMS.WebUI.Models
{
    public class RegXVIPart1ViewModel
    {
        IEnumerable<DCBViewModel> dcbViewModels;

        public RegXVIPart1ViewModel(IEnumerable<DCBViewModel> argDCBViewModels)
        {
            dcbViewModels = argDCBViewModels;
            //goToVillagesCess=argGoToVillagesCess;
            //comeFromVillagesCess=argComeFromVillagesCess;
        }


        public IEnumerable<DCBViewModel> DCBViewModels
        {
            get { return dcbViewModels; }

        }

        public DemandCess TotalDemandCess
        {
            get
            {
                return new DemandCess
                {
                    MoreThanThree = dcbViewModels.Sum(d => d.DemandCess.MoreThanThree),
                    Third = dcbViewModels.Sum(d => d.DemandCess.Third),
                    Second = dcbViewModels.Sum(d => d.DemandCess.Second),
                    Previous = dcbViewModels.Sum(d => d.DemandCess.Previous),
                    Current = dcbViewModels.Sum(d => d.DemandCess.Current),
                    Advance = dcbViewModels.Sum(d => d.DemandCess.Advance),
                    Increase = dcbViewModels.Sum(d => d.DemandCess.Increase)
                };
            }

        }
        public DemandCess TotalDemandAfterIncrementCess
        {
            get
            {
                TotalDemandCess.Current = TotalDemandCess.Current + TotalDemandCess.Increase;
                return TotalDemandCess;
            }

        }
        public CollectionCess TotalCollectionCess
        {
            get
            {
                return new CollectionCess
                {
                    MoreThanThree = dcbViewModels.Sum(d => d.NetCollectionCess.MoreThanThree),
                    Third = dcbViewModels.Sum(d => d.NetCollectionCess.Third),
                    Second = dcbViewModels.Sum(d => d.NetCollectionCess.Second),
                    Previous = dcbViewModels.Sum(d => d.NetCollectionCess.Previous),
                    Current = dcbViewModels.Sum(d => d.NetCollectionCess.Current),
                    Advance = dcbViewModels.Sum(d => d.NetCollectionCess.Advance)
                };
            }

        }
        public BalanceCess TotalBalanceCess
        {
            get
            {
                return new BalanceCess
                {
                    MoreThanThree = dcbViewModels.Sum(d => d.BalanceCess.MoreThanThree),
                    Third = dcbViewModels.Sum(d => d.BalanceCess.Third),
                    Second = dcbViewModels.Sum(d => d.BalanceCess.Second),
                    Previous = dcbViewModels.Sum(d => d.BalanceCess.Previous),
                    Current = dcbViewModels.Sum(d => d.BalanceCess.Current),
                    Advance = dcbViewModels.Sum(d => d.BalanceCess.Advance)
                };
            }

        }


        public DemandLandRevenue TotalDemandLandRevenue
        {
            get
            {
                return new DemandLandRevenue
                {

                    MoreThanThree = dcbViewModels.Sum(d => d.DemandLandRevenue.MoreThanThree),
                    Third = dcbViewModels.Sum(d => d.DemandLandRevenue.Third),
                    Second = dcbViewModels.Sum(d => d.DemandLandRevenue.Second),
                    Previous = dcbViewModels.Sum(d => d.DemandLandRevenue.Previous),
                    Current = dcbViewModels.Sum(d => d.DemandLandRevenue.Current),
                    Advance = dcbViewModels.Sum(d => d.DemandLandRevenue.Advance),
                    Increase = dcbViewModels.Sum(d => d.DemandLandRevenue.Increase)
                };
            }

        }

        public DemandLandRevenue TotalDemandAfterIncrementLandRevenue
        {
            get
            {
                TotalDemandLandRevenue.Current = TotalDemandLandRevenue.Current + TotalDemandLandRevenue.Increase;
                return TotalDemandLandRevenue;
            }

        }
        public AdvanceAdjustmentCess TotalAdvanceAdjustmentCess
        {
            get
            {
                return new AdvanceAdjustmentCess
                {
                    Current = dcbViewModels.Sum(a => a.AdvanceAdjustmentCess.Current)
                };
            }
        }
        public AdvanceAdjustmentWaterTax TotalAdvanceAdjustmentWaterTax
        {
            get
            {
                return new AdvanceAdjustmentWaterTax
                {
                    Current = dcbViewModels.Sum(a => a.AdvanceAdjustmentWaterTax.Current)
                };
            }
        }
        public DemandLandRevenue TotalDemandWaterTax
        {
            get
            {
                return new DemandLandRevenue
                {
                    MoreThanThree = dcbViewModels.Sum(d => d.DemandWaterTax.MoreThanThree),
                    Third = dcbViewModels.Sum(d => d.DemandWaterTax.Third),
                    Second = dcbViewModels.Sum(d => d.DemandWaterTax.Second),
                    Previous = dcbViewModels.Sum(d => d.DemandWaterTax.Previous),
                    Current = dcbViewModels.Sum(d => d.DemandWaterTax.Current),
                    Advance = dcbViewModels.Sum(d => d.DemandWaterTax.Advance),
                    Increase = dcbViewModels.Sum(d => d.DemandWaterTax.Increase)
                };
            }

        }
        public CollectionLandRevenue TotalCollectionLandRevenue
        {
            get
            {
                return new CollectionLandRevenue
                {
                    MoreThanThree = dcbViewModels.Sum(d => d.NetCollectionLandRevenue.MoreThanThree),
                    Third = dcbViewModels.Sum(d => d.NetCollectionLandRevenue.Third),
                    Second = dcbViewModels.Sum(d => d.NetCollectionLandRevenue.Second),
                    Previous = dcbViewModels.Sum(d => d.NetCollectionLandRevenue.Previous),
                    Current = dcbViewModels.Sum(d => d.NetCollectionLandRevenue.Current),
                    Advance = dcbViewModels.Sum(d => d.NetCollectionLandRevenue.Advance)
                };
            }

        }
        public CollectionLandRevenue TotalCollectionWaterTax
        {
            get
            {
                return new CollectionLandRevenue
                {
                    MoreThanThree = dcbViewModels.Sum(d => d.NetCollectionWaterTax.MoreThanThree),
                    Third = dcbViewModels.Sum(d => d.NetCollectionWaterTax.Third),
                    Second = dcbViewModels.Sum(d => d.NetCollectionWaterTax.Second),
                    Previous = dcbViewModels.Sum(d => d.NetCollectionWaterTax.Previous),
                    Current = dcbViewModels.Sum(d => d.NetCollectionWaterTax.Current),
                    Advance = dcbViewModels.Sum(d => d.NetCollectionWaterTax.Advance)
                };
            }

        }
        public BalanceLandRevenue TotalBalanceLandRevenue
        {
            get
            {
                return new BalanceLandRevenue
                {
                    MoreThanThree = dcbViewModels.Sum(d => d.BalanceLandRevenue.MoreThanThree),
                    Third = dcbViewModels.Sum(d => d.BalanceLandRevenue.Third),
                    Second = dcbViewModels.Sum(d => d.BalanceLandRevenue.Second),
                    Previous = dcbViewModels.Sum(d => d.BalanceLandRevenue.Previous),
                    Current = dcbViewModels.Sum(d => d.BalanceLandRevenue.Current),
                    Advance = dcbViewModels.Sum(d => d.BalanceLandRevenue.Advance)
                };
            }

        }
        public BalanceWaterTax TotalBalanceWaterTax
        {
            get
            {
                return new BalanceWaterTax
                {
                    MoreThanThree = dcbViewModels.Sum(d => d.BalanceWaterTax.MoreThanThree),
                    Third = dcbViewModels.Sum(d => d.BalanceWaterTax.Third),
                    Second = dcbViewModels.Sum(d => d.BalanceWaterTax.Second),
                    Previous = dcbViewModels.Sum(d => d.BalanceWaterTax.Previous),
                    Current = dcbViewModels.Sum(d => d.BalanceWaterTax.Current),
                    Advance = dcbViewModels.Sum(d => d.BalanceWaterTax.Advance)
                };
            }

        }
        public DemandPartOneRev TotalDemandPartOneRev
        {
            get
            {
                return new DemandPartOneRev
                {
                    MoreThanThree = TotalDemandCess.MoreThanThree + TotalDemandLandRevenue.MoreThanThree + TotalDemandWaterTax.MoreThanThree,
                    Third = TotalDemandCess.Third + TotalDemandLandRevenue.Third + TotalDemandWaterTax.Third,
                    Second = TotalDemandCess.Second + TotalDemandLandRevenue.Second + TotalDemandWaterTax.Second,
                    Previous = TotalDemandCess.Previous + TotalDemandLandRevenue.Previous + TotalDemandWaterTax.Previous,
                    Current = TotalDemandCess.Current + TotalDemandLandRevenue.Current + TotalDemandWaterTax.Current,
                    Advance = TotalDemandCess.Advance + TotalDemandLandRevenue.Advance + TotalDemandWaterTax.Advance,
                    Increase=TotalDemandCess.Increase+TotalDemandLandRevenue.Increase+TotalDemandWaterTax.Increase
                };
            }
        }
        public PartOneRev TotalCollectionPartOneRev
        {
            get
            {
                return new PartOneRev
                {
                    MoreThanThree = TotalCollectionCess.MoreThanThree + TotalCollectionLandRevenue.MoreThanThree + TotalCollectionWaterTax.MoreThanThree,
                    Third = TotalCollectionCess.Third + TotalCollectionLandRevenue.Third + TotalCollectionWaterTax.Third,
                    Second = TotalCollectionCess.Second + TotalCollectionLandRevenue.Second + TotalCollectionWaterTax.Second,
                    Previous = TotalCollectionCess.Previous + TotalCollectionLandRevenue.Previous + TotalCollectionWaterTax.Previous,
                    Current = TotalCollectionCess.Current + TotalCollectionLandRevenue.Current + TotalCollectionWaterTax.Current,
                    Advance = TotalCollectionCess.Advance + TotalCollectionLandRevenue.Advance + TotalCollectionWaterTax.Advance

                };
            }
        }
        public PartOneRev TotalBalancePartOneRev
        {
            get
            {
                return new PartOneRev
                {
                    MoreThanThree = TotalBalanceCess.MoreThanThree + TotalBalanceLandRevenue.MoreThanThree + TotalBalanceWaterTax.MoreThanThree,
                    Third = TotalBalanceCess.Third + TotalBalanceLandRevenue.Third + TotalBalanceWaterTax.Third,
                    Second = TotalBalanceCess.Second + TotalBalanceLandRevenue.Second + TotalBalanceWaterTax.Second,
                    Previous = TotalBalanceCess.Previous + TotalBalanceLandRevenue.Previous + TotalBalanceWaterTax.Previous,
                    Current = TotalBalanceCess.Current + TotalBalanceLandRevenue.Current + TotalBalanceWaterTax.Current,
                    Advance = TotalBalanceCess.Advance + TotalBalanceLandRevenue.Advance + TotalBalanceWaterTax.Advance

                };
            }
        }
    }
}