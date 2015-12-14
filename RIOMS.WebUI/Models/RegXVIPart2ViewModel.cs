using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RIOMS.Domain;
namespace RIOMS.WebUI.Models
{
    public class RegXVIPart2ViewModel
    {
        IEnumerable<DCBXVI2ViewModel> dcbXVI2ViewModels;
        public RegXVIPart2ViewModel(IEnumerable<DCBXVI2ViewModel> argdcbXVI2ViewModel)
        {
            dcbXVI2ViewModels = argdcbXVI2ViewModel;
        }
        public IEnumerable<DCBXVI2ViewModel> DCBXVI2ViewModels { get { return dcbXVI2ViewModels; } }
        public DemandMiscRevenue TotalDemand
        {
            get
            {
                return new DemandMiscRevenue
                {
                    Arrear = dcbXVI2ViewModels.Sum(m => m.Demand.Arrear),
                    Current = dcbXVI2ViewModels.Sum(m => m.Demand.Current)
                };
            }

        }
        public CollectionMiscRevenue TotalCollection
        {
            get
            {
                return new CollectionMiscRevenue
                {
                    Arrear = dcbXVI2ViewModels.Sum(m => m.TotalCollectionAfterTah.Arrear),
                    Current = dcbXVI2ViewModels.Sum(m => m.TotalCollectionAfterTah.Current),
                    Interest = dcbXVI2ViewModels.Sum(m => m.TotalCollectionAfterTah.Interest)
                };
            }

        }
        public DemandMiscRevenue TotalBalance
        {
            get
            {
                return new DemandMiscRevenue
                {
                    Arrear = dcbXVI2ViewModels.Sum(m => m.Balance.Arrear),
                    Current = dcbXVI2ViewModels.Sum(m => m.Balance.Current)
                };
            }

        }
        public decimal TotalCollectionIntrestLR
        { 
            get
            {
                return dcbXVI2ViewModels.Sum(m =>m.CollectionIntrestLR);
               
            }

        }
        public decimal TotalCollectionIntrestCess
        {
            get { return dcbXVI2ViewModels.Sum(m => m.CollectionIntrestCess); }
        }
        public decimal TotalCollectionIntrestWaterTax
        {
            get { return dcbXVI2ViewModels.Sum(m => m.CollectionIntrestWaterTax); }
        }
       
        public decimal TotalCollectionDF
        {
            get { return dcbXVI2ViewModels.Sum(m => m.CollectionDF); }

        }
        public decimal TotalCollectionLPB
        {
            get { return dcbXVI2ViewModels.Sum(m => m.CollectionLPB); }

        }
        public decimal TotalCollectionProcessingFee
        {
            get { return dcbXVI2ViewModels.Sum(m => m.CollectionProcessingFee); }

        }
        public decimal TotalCollectionPremium
        {
            get { return dcbXVI2ViewModels.Sum(m => m.CollectionPremium); }
        }
    }
}