using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RIOMS.Domain;
using RIOMS.Domain.Models;

namespace RIOMS.WebUI.Models
{
    public class MFormAbstractViewModel
    {
        IEnumerable<DCBViewModel> dcbViewModel;
        public MFormAbstractViewModel(IEnumerable<DCBViewModel> argdcbViewModel)
        {
            dcbViewModel = argdcbViewModel;
        }
        public IEnumerable<DCBViewModel> DCBViewModels { get { return dcbViewModel; } }


        public PartOneRev CessTotal
        {
            get
            {

                return new PartOneRev
                {
                    MoreThanThree = dcbViewModel.Sum(d => d.BalanceCess.MoreThanThree),
                    Third = dcbViewModel.Sum(d => d.BalanceCess.Third),
                    Second=dcbViewModel.Sum(d=>d.BalanceCess.Second),
                    Previous=dcbViewModel.Sum(d=>d.BalanceCess.Previous),
                    Current=dcbViewModel.Sum(d=>d.BalanceCess.Current)

                };
            }
        }

        public PartOneRev CBWRTotal
        {
            get
            {

                return new PartOneRev
                {
                    MoreThanThree = dcbViewModel.Sum(d => d.BalanceWaterTax.MoreThanThree),
                    Third = dcbViewModel.Sum(d => d.BalanceWaterTax.Third),
                    Second = dcbViewModel.Sum(d => d.BalanceWaterTax.Second),
                    Previous = dcbViewModel.Sum(d => d.BalanceWaterTax.Previous),
                    Current = dcbViewModel.Sum(d => d.BalanceWaterTax.Current)

                };
            }
        }
        public PartOneRev LRTotal
        {
            get
            {

                return new PartOneRev
                {
                    MoreThanThree = dcbViewModel.Sum(d => d.BalanceLandRevenue.MoreThanThree),
                    Third = dcbViewModel.Sum(d => d.BalanceLandRevenue.Third),
                    Second = dcbViewModel.Sum(d => d.BalanceLandRevenue.Second),
                    Previous = dcbViewModel.Sum(d => d.BalanceLandRevenue.Previous),
                    Current = dcbViewModel.Sum(d => d.BalanceLandRevenue.Current)

                };
            }
        }
    }
}