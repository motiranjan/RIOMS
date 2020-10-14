using System;
using System.Collections.Generic;
using System.Linq;
using RIOMS.Domain.Models;

namespace RIOMS.Domain.Models
{
    public partial class Receipt
    {
        public static Receipt operator +(Receipt r1, Receipt r2)
        {
            Receipt result = new Receipt { CollectionCess = new CollectionCess(), CollectionWaterTax = new CollectionWaterTax(), CollectionLandRevenue = new CollectionLandRevenue(), CollectionMiscRevenue = new CollectionMiscRevenue(), CollectionOther = new CollectionOther(), CollectionOLR = new CollectionOLR(),CollectionOPDR=new CollectionOPDR() };
            result.CollectionCess.Current = r1.CollectionCess.Current + r2.CollectionCess.Current;
            result.CollectionCess.Previous = r1.CollectionCess.Previous + r2.CollectionCess.Previous;
            result.CollectionCess.Second = r1.CollectionCess.Second + r2.CollectionCess.Second;
            result.CollectionCess.Third = r1.CollectionCess.Third + r2.CollectionCess.Third;
            result.CollectionCess.MoreThanThree = r1.CollectionCess.MoreThanThree + r2.CollectionCess.MoreThanThree;
            result.CollectionCess.InterestTotal = r1.CollectionCess.InterestTotal + r2.CollectionCess.InterestTotal;
            /*--------------------------------------------------------------------------------------------------*/
            result.CollectionWaterTax.Current = r1.CollectionWaterTax.Current + r2.CollectionWaterTax.Current;
            result.CollectionWaterTax.Previous = r1.CollectionWaterTax.Previous + r2.CollectionWaterTax.Previous;
            result.CollectionWaterTax.Second = r1.CollectionWaterTax.Second + r2.CollectionWaterTax.Second;
            result.CollectionWaterTax.Third = r1.CollectionWaterTax.Third + r2.CollectionWaterTax.Third;
            result.CollectionWaterTax.MoreThanThree = r1.CollectionWaterTax.MoreThanThree + r2.CollectionWaterTax.MoreThanThree;
            result.CollectionWaterTax.InterestTotal = r1.CollectionWaterTax.InterestTotal + r2.CollectionWaterTax.InterestTotal;
            /*----------------------------------------------------------------------------------------------------------------*/
            result.CollectionLandRevenue.Current = r1.CollectionLandRevenue.Current + r2.CollectionLandRevenue.Current;
            result.CollectionLandRevenue.Previous = r1.CollectionLandRevenue.Previous + r2.CollectionLandRevenue.Previous;
            result.CollectionLandRevenue.Second = r1.CollectionLandRevenue.Second + r2.CollectionLandRevenue.Second;
            result.CollectionLandRevenue.Third = r1.CollectionLandRevenue.Third + r2.CollectionLandRevenue.Third;
            result.CollectionLandRevenue.MoreThanThree = r1.CollectionLandRevenue.MoreThanThree + r2.CollectionLandRevenue.MoreThanThree;
            result.CollectionLandRevenue.InterestTotal = r1.CollectionLandRevenue.InterestTotal + r2.CollectionLandRevenue.InterestTotal;
            /*------------------------------------*/
            if (r1.HasMiscRevenue && r2.HasMiscRevenue)
            {
                result.CollectionMiscRevenue.Current = r1.CollectionMiscRevenue.Current + r2.CollectionMiscRevenue.Current;
                result.CollectionMiscRevenue.Arrear = r1.CollectionMiscRevenue.Arrear + r2.CollectionMiscRevenue.Arrear;
                result.CollectionMiscRevenue.Interest = r1.CollectionMiscRevenue.Interest + r2.CollectionMiscRevenue.Interest;
            }
            if (r1.HasOthers && r2.HasOthers)
            {
                result.CollectionOther.Amount = r1.CollectionOther.Amount + r2.CollectionOther.Amount;
            }
            if (r1.HasOLR && r2.HasOLR)
            {
                result.CollectionOLR.Premium = r1.CollectionOLR.Premium + r2.CollectionOLR.Premium;
                result.CollectionOLR.DemarcationFee = r1.CollectionOLR.DemarcationFee + r2.CollectionOLR.DemarcationFee;
            }
            if (r1.HasOPDR && r2.HasOPDR)
            {
                result.CollectionOPDR.Amount = r1.CollectionOPDR.Amount + r2.CollectionOPDR.Amount;
                
            }
            return result;
        }


        public bool HasLandRevenue { get { return this.CollectionLandRevenue != null; } }

        public bool HasWaterTax { get { return this.CollectionWaterTax != null; } }

        public bool HasCess { get { return this.CollectionCess != null; } }

        public bool HasMiscRevenue { get { return this.CollectionMiscRevenue != null; } }

        public bool HasOthers { get { return this.CollectionOther != null; } }
        public bool HasOLR { get { return this.CollectionOLR != null; } }

        public bool HasOPDR { get { return this.CollectionOPDR != null; } }

        public decimal? Total
        {
            get
            {
                decimal? total = 0;
                if (HasCess)
                {
                    total = total + CollectionCess.Total + CollectionCess.InterestTotal;
                }
                if (HasLandRevenue)
                {
                    total = total + CollectionLandRevenue.Total + CollectionLandRevenue.InterestTotal;
                }
                if (HasWaterTax)
                {
                    total = total + CollectionWaterTax.Total + CollectionWaterTax.InterestTotal;
                }
                if (HasMiscRevenue)
                {
                    total = total + CollectionMiscRevenue.Arrear + CollectionMiscRevenue.Current + CollectionMiscRevenue.Interest;
                }
                if (HasOthers)
                {
                    total = total + CollectionOther.Amount;
                }
                if (HasOLR)
                {
                    total = total + CollectionOLR.Premium + CollectionOLR.DemarcationFee;
                }
                if (HasOPDR)
                {
                    total = total + CollectionOPDR.Amount ;
                }
                return total;

            }

        }

    }

    public partial class CollectionCess
    {
        public CollectionCess()
        { }
        public CollectionCess(IEnumerable<Receipt> receipts)
        {
            MoreThanThree = receipts.Sum(r => r.HasCess ? r.CollectionCess.MoreThanThree : 0);
            Third = receipts.Sum(r => r.HasCess ? r.CollectionCess.Third : 0);
            Second = receipts.Sum(r => r.HasCess ? r.CollectionCess.Second : 0);
            Previous = receipts.Sum(r => r.HasCess ? r.CollectionCess.Previous : 0);
            Current = receipts.Sum(r => r.HasCess ? r.CollectionCess.Current : 0);
        }

        public CollectionCess(IEnumerable<IFormDetailCess> iFormDetailCess)
        {
            MoreThanThree = iFormDetailCess.Sum(c => c.MoreThanThree);
            Third = iFormDetailCess.Sum(c => c.Third);
            Second = iFormDetailCess.Sum(c => c.Second);
            Previous = iFormDetailCess.Sum(c => c.Previous);
            Current = iFormDetailCess.Sum(c => c.Current);
        }
        
    }


    

    public partial class CollectionWaterTax
    {
        public CollectionWaterTax()
        {

        }
        public CollectionWaterTax(IEnumerable<Receipt> receipts)
        {
            MoreThanThree = receipts.Sum(r => r.HasWaterTax ? r.CollectionWaterTax.MoreThanThree : 0);
            Third = receipts.Sum(r => r.HasWaterTax ? r.CollectionWaterTax.Third : 0);
            Second = receipts.Sum(r => r.HasWaterTax ? r.CollectionWaterTax.Second : 0);
            Previous = receipts.Sum(r => r.HasWaterTax ? r.CollectionWaterTax.Previous : 0);
            Current = receipts.Sum(r => r.HasWaterTax ? r.CollectionWaterTax.Current : 0);
        }
      
    }

    public partial class CollectionLandRevenue
    {
        public CollectionLandRevenue()
        {

        }
        public CollectionLandRevenue(IEnumerable<Receipt> receipts)
        {
            MoreThanThree = receipts.Sum(r => r.HasLandRevenue ? r.CollectionLandRevenue.MoreThanThree : 0);
            Third = receipts.Sum(r => r.HasLandRevenue ? r.CollectionLandRevenue.Third : 0);
            Second = receipts.Sum(r => r.HasLandRevenue ? r.CollectionLandRevenue.Second : 0);
            Previous = receipts.Sum(r => r.HasLandRevenue ? r.CollectionLandRevenue.Previous : 0);
            Current = receipts.Sum(r => r.HasLandRevenue ? r.CollectionLandRevenue.Current : 0);
        }

    }
    public class BalancePartOneRev : PartOneRev
    {
        public decimal? Advance { get; set; }
    }
    public class BalanceCess : BalancePartOneRev
    {
        
        public BalanceCess()
        {

        }
        public BalanceCess(CollectionCess collection, AdvanceCollectionCess advc, DemandCess demandCess)
        {
            MoreThanThree = demandCess.MoreThanThree - collection.MoreThanThree;
            Third = demandCess.Third - collection.Third;
            Second = demandCess.Second - collection.Second;
            Previous = demandCess.Previous - collection.Previous;
            Current = demandCess.Current - collection.Current;
            Advance = demandCess.Advance + advc.Current.GetValueOrDefault() + advc.Previous.GetValueOrDefault()
                + advc.Second.GetValueOrDefault() + advc.Third.GetValueOrDefault() + advc.MoreThanThree.GetValueOrDefault();
        }
        public BalanceCess(CollectionCess collection, DemandCess demandCess)
        {
           
            if (collection.MoreThanThree > demandCess.MoreThanThree)
            {
                Advance = Advance + collection.MoreThanThree - demandCess.MoreThanThree;
                MoreThanThree = 0;
            }
            else
            {
                MoreThanThree = demandCess.MoreThanThree - collection.MoreThanThree;
            }
            if (collection.Third > demandCess.Third)
            {
                Advance = Advance + collection.Third - demandCess.Third;
                Third = 0;
            }
            else
            {
                Third = demandCess.Third - collection.Third;
            }
            if (collection.Second > demandCess.Second)
            {
                Advance = Advance + collection.Second - demandCess.Second;
                Second = 0;
            }
            else
            {
                Second = demandCess.Second - collection.Second;
            }

            if (collection.Previous > demandCess.Previous)
            {
                Advance = Advance + collection.Previous - demandCess.Previous;
                Previous = 0;

            }
            else
            {
                Previous = demandCess.Previous - collection.Previous;
            }
            if ((demandCess.Advance + collection.Current ) > demandCess.Current)
            {
                Advance = (collection.Current + demandCess.Advance + Advance) - demandCess.Current;
                Current = 0;
            }
            else
            {
                Current = demandCess.Current - (collection.Current +  demandCess.Advance);
               // Advance = 0;
            }

        }
       
        
    }
    public class BalanceWaterTax : BalancePartOneRev
    {
        public BalanceWaterTax()
        { }
        public BalanceWaterTax(CollectionWaterTax collection, AdvanceCollectionWaterTax advc, DemandWaterTax demandWaterTax)
        {
            MoreThanThree = demandWaterTax.MoreThanThree - collection.MoreThanThree;
            Third = demandWaterTax.Third - collection.Third;
            Second = demandWaterTax.Second - collection.Second;
            Previous = demandWaterTax.Previous - collection.Previous;
            Current = demandWaterTax.Current - collection.Current;
            Advance = demandWaterTax.Advance + advc.Current.GetValueOrDefault() + advc.Previous.GetValueOrDefault()
                + advc.Second.GetValueOrDefault() + advc.Third.GetValueOrDefault() + advc.MoreThanThree.GetValueOrDefault();
        }
        public BalanceWaterTax(CollectionWaterTax collection, DemandWaterTax demandWaterTax)
        {
            if (collection.MoreThanThree > demandWaterTax.MoreThanThree)
            {
                Advance = Advance + collection.MoreThanThree - demandWaterTax.MoreThanThree;
                MoreThanThree = 0;
            }
            else
            {
                MoreThanThree = demandWaterTax.MoreThanThree - collection.MoreThanThree;
            }
            if (collection.Third > demandWaterTax.Third)
            {
                Advance = Advance + collection.Third - demandWaterTax.Third;
                Third = 0;
            }
            else
            {
                Third = demandWaterTax.Third - collection.Third;
            }
            if (collection.Second > demandWaterTax.Second)
            {
                Advance = Advance + collection.Second - demandWaterTax.Second;
                Second = 0;
            }
            else
            {
                Second = demandWaterTax.Second - collection.Second;
            }

            if (collection.Previous > demandWaterTax.Previous)
            {
                Advance = Advance + collection.Previous - demandWaterTax.Previous;
                Previous = 0;

            }
            else
            {
                Previous = demandWaterTax.Previous - collection.Previous;
            }
            if ((demandWaterTax.Advance + collection.Current + Advance) > demandWaterTax.Current)
            {
                Advance = (collection.Current + demandWaterTax.Advance + Advance) - demandWaterTax.Current;
                Current = 0;
            }
            else
            {
                Current = demandWaterTax.Current - (collection.Current + demandWaterTax.Advance + Advance);
                Advance = 0;
            }
        }
       
        
}
    public class BalanceLandRevenue : BalancePartOneRev
    {
        public BalanceLandRevenue()
        { }
        public BalanceLandRevenue(CollectionLandRevenue collection, AdvanceCollectionLandRevenue advc, DemandLandRevenue demandLR)
        {
            MoreThanThree = demandLR.MoreThanThree - collection.MoreThanThree;
            Third = demandLR.Third - collection.Third;
            Second = demandLR.Second - collection.Second;
            Previous = demandLR.Previous - collection.Previous;
            Current = demandLR.Current - collection.Current;
            Advance = demandLR.Advance + advc.Current.GetValueOrDefault() + advc.Previous.GetValueOrDefault()
                + advc.Second.GetValueOrDefault() + advc.Third.GetValueOrDefault() + advc.MoreThanThree.GetValueOrDefault();
        }
        public BalanceLandRevenue(CollectionLandRevenue collection, DemandLandRevenue demandLR)
        {
            if (collection.MoreThanThree > demandLR.MoreThanThree)
            {
                Advance = Advance + collection.MoreThanThree - demandLR.MoreThanThree;
                MoreThanThree = 0;
            }
            else
            {
                MoreThanThree = demandLR.MoreThanThree - collection.MoreThanThree;
            }
            if (collection.Third > demandLR.Third)
            {
                Advance = Advance + collection.Third - demandLR.Third;
                Third = 0;
            }
            else
            {
                Third = demandLR.Third - collection.Third;
            }
            if (collection.Second > demandLR.Second)
            {
                Advance = Advance + collection.Second - demandLR.Second;
                Second = 0;
            }
            else
            {
                Second = demandLR.Second - collection.Second;
            }

            if (collection.Previous > demandLR.Previous)
            {
                Advance = Advance + collection.Previous - demandLR.Previous;
                Previous = 0;

            }
            else
            {
                Previous = demandLR.Previous - collection.Previous;
            }
            if ((demandLR.Advance + collection.Current + Advance) > demandLR.Current)
            {
                Advance = (collection.Current + demandLR.Advance + Advance) - demandLR.Current;
                Current = 0;
            }
            else
            {
                Current = demandLR.Current - (collection.Current + demandLR.Advance + Advance);
                Advance = 0;
            }
        }
       

    }
    public partial class Khata
    {
        public CollectionCess CollectionCess
        {
            get { return new CollectionCess(Receipts); }

        }
        public CollectionWaterTax CollectionWaterTax
        {
            get { return new CollectionWaterTax(Receipts); }
        }
        public CollectionLandRevenue CollectionLandRevenue
        {
            get { return new CollectionLandRevenue(Receipts); }
        }
        public decimal TotalArea { 
            get {
            if (Plots.Count>0)
            {
                return Plots.Sum(p => p.Area).Value;
            }
            else
            {
                return 0;
            }
        
        } }
        public BalanceCess BalanceCess
        {
            get
            {
                if (DemandCesses.Count > 0)
                {
                    return new BalanceCess(CollectionCess, DemandCesses.ToList()[0]);
                }
                else
                {
                    return null;
                }
            }

        }
        public BalanceWaterTax BalanceWaterTax
        {
            get
            {
                if (DemandWaterTaxes.Count > 0)
                {
                    return new BalanceWaterTax(CollectionWaterTax, DemandWaterTaxes.ToList()[0]);
                }
                else
                {
                    return null;
                }
            }
        }

        public BalanceLandRevenue BalanceLandRevenue
        {
            get
            {
                if (DemandLandRevenues.Count>0)
                {
                    return new BalanceLandRevenue(CollectionLandRevenue, DemandLandRevenues.ToList()[0]);
                }
                else
                {
                    return null;
                }
            }
        }
    }


}
