using RIOMS.Domain;
using RIOMS.Domain.Models;
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
        #region Demand
        public PartOneRev TotalDemandLandRevenue
        {
            get
            {
                return dcbViewModels.Select(d => d.DemandLandRevenue).Sum();
            }

        }
        public PartOneRev TotalDemandCess
        {
            get
            {
                return dcbViewModels.Select(d => d.DemandCess).Sum();
            }
        }
        public PartOneRev TotalDemandWaterTax
        {
            get
            {
                return dcbViewModels.Select(d => d.DemandWaterTax).Sum();
            }

        }
        public PartOneRev TotalDemandPartOneRev
        {
            get
            {
                return TotalDemandCess + TotalDemandLandRevenue + TotalDemandWaterTax;
            }
        }
        #endregion

        #region Increase in demand
        public PartOneRev TotalIncreaseInDemandLandRevenue
        {
            get
            {
                return dcbViewModels.Select(d => d.IncreaseInDemandLandRevenue).Sum();
            }
        }
        public PartOneRev TotalIncreaseInDemandCess
        {
            get
            {
                return dcbViewModels.Select(d => d.IncreaseInDemandCess).Sum();
            }
        }
        public PartOneRev TotalIncreaseInDemandPartOneRev
        {
            get
            {
                return TotalIncreaseInDemandCess + TotalIncreaseInDemandLandRevenue;
            }
        }
        #endregion

        #region Demand after Increase
        public PartOneRev TotalDemandAfterIncrementCess
        {
            get
            {
                return dcbViewModels.Select(d => d.DemandAfterIncreaseCess).Sum();
            }
        }
        public PartOneRev TotalDemandAfterIncreaseLandRevenue
        {
            get
            {
                return dcbViewModels.Select(d => d.DemandAfterIncreaseLandRevenue).Sum();
            }

        }
        public PartOneRev TotalDemandAfterIncreaseWaterTax
        {
            get
            {
                return dcbViewModels.Select(d => d.DemandAfterIncreaseWaterTax).Sum();
            }

        }
        public PartOneRev TotalDemandAfterIncreasePartOneRev
        {
            get
            {
                return dcbViewModels.Select(d => d.DemandAfterIncreasePartOneRev).Sum();
            }

        }
        #endregion

        public PartOneRev TotalCollectionCess
        {
            get
            {
                return dcbViewModels.Select(d => d.NetCollectionCess).Sum();
            }

        }




        #region adv adj
        public PartOneRev TotalAdvanceAdjustmentCess
        {
            get
            {
                return dcbViewModels.Select(d => d.AdvanceAdjustmentCess).Sum();


            }
        }
        public PartOneRev TotalAdvanceAdjustmentLandRevenue
        {
            get
            {
                return dcbViewModels.Select(d => d.AdvanceAdjustmentLandRevenue).Sum();


            }
        }
        public PartOneRev TotalAdvanceAdjustmentWaterTax
        {
            get
            {
                return dcbViewModels.Select(d => d.AdvanceAdjustmentWaterTax).Sum();
            }
        }
        public PartOneRev TotalAdvanceAdjustmentPartOneRev
        {
            get
            {
                return TotalAdvanceAdjustmentCess + TotalAdvanceAdjustmentLandRevenue + TotalAdvanceAdjustmentWaterTax;
            }
        }

        #endregion

        public PartOneRev TotalCollectionLandRevenue
        {
            get
            {
                return dcbViewModels.Select(d => d.NetCollectionLandRevenue).Sum();
            }

        }
        public PartOneRev TotalCollectionWaterTax
        {
            get
            {
                return dcbViewModels.Select(d => d.NetCollectionWaterTax).Sum();
            }

        }
        #region Balance
        public PartOneRev TotalBalanceLandRevenue
        {
            get
            {
                return dcbViewModels.Select(d => d.BalanceLandRevenue).Sum();
            }

        }
        public PartOneRev TotalBalanceCess
        {
            get
            {
                return dcbViewModels.Select(d => d.BalanceCess).Sum();
            }
        }

        public PartOneRev TotalBalancePartOneRev
        {
            get
            {
                return TotalBalanceCess + TotalBalanceLandRevenue + TotalBalanceWaterTax;
            }
        }
        public PartOneRev TotalBalanceWaterTax
        {
            get
            {
                return dcbViewModels.Select(d => d.BalanceWaterTax).Sum();
            }

        }

        #endregion


        public PartOneRev TotalCollectionPartOneRev
        {
            get
            {
                return TotalCollectionCess + TotalCollectionLandRevenue + TotalCollectionWaterTax;
            }
        }
        #region Advance collection
        public PartOneRev TotalAdvanceCollectionLandRevenue
        {
            get
            {
                return dcbViewModels.Select(d => d.AdvanceCollectionLandRevenue).Sum();
            }

        }
        public PartOneRev TotalAdvanceCollectionCess
        {
            get
            {
                return dcbViewModels.Select(d => d.AdvanceCollectionCess).Sum();
            }
        }

        public PartOneRev TotalAdvanceCellectionPartOneReve
        {
            get
            {
                return TotalAdvanceCollectionCess + TotalBalanceLandRevenue + TotalBalanceWaterTax;
            }
        }
        public PartOneRev TotalAdvanceCollectionWaterTax
        {
            get
            {
                return dcbViewModels.Select(d => d.AdvanceCollectionWaterTax).Sum();
            }

        }
        #endregion
    }
}