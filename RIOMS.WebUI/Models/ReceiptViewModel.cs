using RIOMS.Domain;
using RIOMS.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace RIOMS.WebUI.Models
{
    public class ReceiptViewModel
    {
        private IEnumerable<Receipt> receipts;
        private List<Receipt> totals;

        public ReceiptViewModel(IEnumerable<Receipt> argReceipts)
        {
            receipts = argReceipts.OrderBy(r => r.Date).ThenBy(r => r.BookNo).ToList();
            totals = receipts.GroupBy(r => r.Date).Select(t => new Receipt
            {
                Date = t.FirstOrDefault().Date,
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
                },
                CollectionOLR = new CollectionOLR
                {
                    Premium = t.Sum(r => r.HasOLR ? r.CollectionOLR.Premium : 0),
                    DemarcationFee = t.Sum(r => r.HasOLR ? r.CollectionOLR.DemarcationFee : 0)
                },
                CollectionOPDR = new CollectionOPDR
                {
                    Amount = t.Sum(r => r.HasOPDR ? r.CollectionOPDR.Amount : 0),
                }
            }).ToList();
        }

        public IEnumerable<Receipt> Receipts { get { return receipts; } }
        public List<Receipt> Totals { get { return totals; } }
    }

    public class VillageWariViewModel
    {
        private IEnumerable<Receipt> receipts;
        private IEnumerable<Receipt> totals;

        public VillageWariViewModel(IEnumerable<Receipt> argReceipts)
        {
            receipts = argReceipts.Where(r => r.HasCess || r.HasLandRevenue || r.HasWaterTax).OrderBy(r => r.Date).ThenBy(r => r.BookNo).ToList();
            totals = receipts.GroupBy(r => r.Date).Select(t => new Receipt
            {
                Date = t.FirstOrDefault().Date,

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
                    Arrear = t.Sum(r => r.HasMiscRevenue ? r.CollectionMiscRevenue.Arrear : 0),
                    Current = t.Sum(r => r.HasMiscRevenue ? r.CollectionMiscRevenue.Current : 0),
                    Interest = t.Sum(r => r.HasMiscRevenue ? r.CollectionMiscRevenue.Interest : 0),
                },
                CollectionOPDR = new CollectionOPDR
                {
                    Amount = t.Sum(r => r.HasOPDR ? r.CollectionOPDR.Amount : 0)
                }
            });
        }

        public IEnumerable<Receipt> Receipts { get { return receipts; } }
        public IEnumerable<Receipt> Totals { get { return totals; } }
    }
}