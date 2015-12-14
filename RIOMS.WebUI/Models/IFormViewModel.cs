using RIOMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIOMS.WebUI.Models
{
    public class IFormViewModel
    {
        IEnumerable<Receipt> villageWiseDetails;
        int challanNo;
        DateTime fromDate;
        DateTime todate;
        Receipt total = new Receipt { CollectionCess = new CollectionCess(), CollectionLandRevenue = new CollectionLandRevenue(), CollectionWaterTax = new CollectionWaterTax(), CollectionMiscRevenue = new CollectionMiscRevenue(), CollectionOther = new CollectionOther(),CollectionOLR=new CollectionOLR() };
        public IFormViewModel(IEnumerable<Receipt> receipts,IForm iform)
        {
            challanNo = iform.IFormNo;
            fromDate = iform.FromDate;
            todate = iform.ToDate;
            villageWiseDetails = receipts.OrderBy(r=>r.VillageId).GroupBy(r => r.VillageId).Select(t => new Receipt
            {
                Village = t.FirstOrDefault().Village,
                CollectionCess = new CollectionCess
                {
                    MoreThanThree = t.Sum(r => r.HasCess ? r.CollectionCess.MoreThanThree : 0),
                    Current = t.Sum(r => r.HasCess ? r.CollectionCess.Current : 0),
                    Second = t.Sum(r => r.HasCess ? r.CollectionCess.Second : 0),
                    Previous = t.Sum(r => r.HasCess ? r.CollectionCess.Previous : 0),
                    Third = t.Sum(r => r.HasCess ? r.CollectionCess.Third : 0),

                    InterestTotal = t.Sum(r => r.HasCess ? r.CollectionCess.InterestTotal : 0),

                },
                CollectionLandRevenue = new CollectionLandRevenue
                {
                    MoreThanThree = t.Sum(r => r.HasLandRevenue ? r.CollectionLandRevenue.MoreThanThree : 0),
                    Current = t.Sum(r => r.HasLandRevenue ? r.CollectionLandRevenue.Current : 0),
                    Second = t.Sum(r => r.HasLandRevenue ? r.CollectionLandRevenue.Second : 0),
                    Previous = t.Sum(r => r.HasLandRevenue ? r.CollectionLandRevenue.Previous : 0),
                    Third = t.Sum(r => r.HasLandRevenue ? r.CollectionLandRevenue.Third : 0),

                    InterestTotal = t.Sum(r => r.HasLandRevenue ? r.CollectionLandRevenue.InterestTotal : 0)
                },
                CollectionWaterTax = new CollectionWaterTax
                {
                    MoreThanThree = t.Sum(r => r.HasWaterTax ? r.CollectionWaterTax.MoreThanThree : 0),
                    Current = t.Sum(r => r.HasWaterTax ? r.CollectionWaterTax.Current : 0),
                    Second = t.Sum(r => r.HasWaterTax ? r.CollectionWaterTax.Second : 0),
                    Previous = t.Sum(r => r.HasWaterTax ? r.CollectionWaterTax.Previous : 0),
                    Third = t.Sum(r => r.HasWaterTax ? r.CollectionWaterTax.Third : 0),
                    InterestTotal = t.Sum(r => r.HasWaterTax ? r.CollectionWaterTax.InterestTotal : 0)
                },
                CollectionMiscRevenue = new CollectionMiscRevenue
                {
                    Current = t.Sum(r => r.HasMiscRevenue ? r.CollectionMiscRevenue.Current : 0),
                    Arrear = t.Sum(r => r.HasMiscRevenue ? r.CollectionMiscRevenue.Arrear : 0),
                    Interest = t.Sum(r => r.HasMiscRevenue ? r.CollectionMiscRevenue.Interest : 0)
                },
                CollectionOther = new CollectionOther
                {
                    Amount = t.Sum(r => r.HasOthers ? r.CollectionOther.Amount : 0)
                } ,
                CollectionOLR = new CollectionOLR
                {
                    Premium = t.Sum(r => r.HasOLR ? r.CollectionOLR.Premium : 0),
                    DemarcationFee = t.Sum(r => r.HasOLR ? r.CollectionOLR.DemarcationFee : 0)
                }
            });
            foreach (var receipt in villageWiseDetails)
            {
                total = total + receipt;
            }
            demarcationFee = receipts.Where(r => r.HasOthers == true && r.CollectionOther.Type == "DF").Sum(r => r.CollectionOther.Amount) +
                receipts.Where(r => r.HasOLR == true ).Sum(r => r.CollectionOLR.DemarcationFee);
            arrearCBWR = total.CollectionWaterTax.MoreThanThree + total.CollectionWaterTax.Third + total.CollectionWaterTax.Second + total.CollectionWaterTax.Previous;
            arrearCess = total.CollectionCess.MoreThanThree + total.CollectionCess.Third + total.CollectionCess.Second + total.CollectionCess.Previous;
            OlrPremium = receipts.Where(r => r.HasOLR == true).Sum(r => r.CollectionOLR.Premium);
        }

        public IFormViewModel(IForm iform)
        {
            challanNo = iform.IFormNo;
            fromDate = iform.FromDate;
            todate = iform.ToDate;
            
        }
        public IEnumerable<Receipt> VillageWiseDetails { get { return villageWiseDetails; } }
        public int ChallanNo { get { return challanNo; } }
        public DateTime FromDate { get { return fromDate; } }
        public DateTime ToDate { get { return todate; } }
        public Receipt Total { get { return total; } }


        public decimal CurrentCBWR { get { return total.CollectionWaterTax.Current; } }
        decimal arrearCBWR;
        public decimal ArrearCBWR { get { return arrearCBWR; } }

        private decimal arrearCess;

        public decimal ArrearCess
        {
            get { return arrearCess; }
            
        }


        public decimal CurrentCess
        {
            get { return total.CollectionCess.Current; }
        }
        private decimal demarcationFee;

        public decimal DemarcationFee
        {
            get { return demarcationFee; }
            
        }
        private decimal OlrPremium;

        public decimal OLRPremium
        {
            get { return OlrPremium; }
        }
        public decimal ArrearMiscRev
        {
            get { return total.CollectionMiscRevenue.Arrear; }
        }
        public decimal CurrentMiscRev
        {
            get { return total.CollectionMiscRevenue.Current; }
        }
        public decimal IntrestOnMiscRev
        {
            get { return total.CollectionMiscRevenue.Interest; }
        }
        public decimal IntrestOnCBWR
        {
            get { return total.CollectionWaterTax.InterestTotal; }
        }
        public decimal InterestOnCess
        {
            get { return total.CollectionCess.InterestTotal; }
        }
        public decimal ArrearLR
        {
            get { return total.CollectionLandRevenue.MoreThanThree + total.CollectionLandRevenue.Third + total.CollectionLandRevenue.Second + total.CollectionLandRevenue.Previous; }
        }
        public decimal CurrentLR
        {
            get
            {
                return total.CollectionLandRevenue.Current;
            }
        }
        public decimal IntrestOnLR
        {
            get { return total.CollectionLandRevenue.InterestTotal; }
        }
    }
}