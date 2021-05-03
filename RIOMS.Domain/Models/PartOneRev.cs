using System;
using System.Collections.Generic;
using System.Linq;

namespace RIOMS.Domain.Models
{
    public class PartOneRev
    {

        public decimal Current { get; set; }
        public decimal Previous { get; set; }
        public decimal Second { get; set; }
        public decimal Third { get; set; }
        public decimal MoreThanThree { get; set; }

        public decimal Advance { get; set; }
        public decimal InterestTotal { get; set; }
       
        public decimal Total
        {
            get
            {
                return MoreThanThree + Third + Second + Previous + Current;
            }

        }
        public decimal Arrear
        {
            get
            {
                return MoreThanThree + Third + Second + Previous;
            }

        }
        public static PartOneRev operator +(PartOneRev r1, PartOneRev r2)
        {

            if (r1 != null && r2 != null)
            {
                return new PartOneRev
                {
                    Current = r1.Current + r2.Current,
                    Previous = r1.Previous + r2.Previous,
                    Second = r1.Second + r2.Second,
                    Third = r1.Third + r2.Third,
                    MoreThanThree = r1.MoreThanThree + r2.MoreThanThree,
                    Advance = r1.Advance + r2.Advance,
                    InterestTotal = r1.InterestTotal + r2.InterestTotal
                };
            }
            else
            {
                return r1 ?? r2;
            }

        }
        public static PartOneRev operator -(PartOneRev r1, PartOneRev r2) 
        {
            PartOneRev result= new PartOneRev
            {
                Current = r1.Current - r2.Current,
                Previous = r1.Previous - r2.Previous,
                Second = r1.Second - r2.Second,
                Third = r1.Third - r2.Third,
                MoreThanThree = r1.MoreThanThree - r2.MoreThanThree,
                Advance = r1.Advance - r2.Advance,
                InterestTotal = r1.InterestTotal - r2.InterestTotal
            };
            return result;
        }
    }

    public static class PartOneRevExt
    {
        public static PartOneRev Sum<T>(this IEnumerable<T> partOneRevs) where T : PartOneRev
        {
            try
            {
                PartOneRev partOneRev = new PartOneRev
                {
                    MoreThanThree = partOneRevs.Sum(t => t.MoreThanThree),
                    Third = partOneRevs.Sum(t => t.Third),
                    Second = partOneRevs.Sum(t => t.Second),
                    Previous = partOneRevs.Sum(t => t.Previous),
                    Current = partOneRevs.Sum(t => t.Current),
                    InterestTotal = partOneRevs.Sum(t => t.InterestTotal)
                };
                if (typeof(T) == typeof(AdvanceCollectionCess) || typeof(T) == typeof(AdvanceCollectionLandRevenue) || typeof(T) == typeof(AdvanceCollectionWaterTax))
                {
                    partOneRev.Advance = partOneRev.Total;
                }
                if (typeof(T) == typeof(AdvanceAdjustmentCess) || typeof(T) == typeof(AdvanceAdjustmentLandRevenue) || typeof(T) == typeof(AdvanceAdjustmentWaterTax))
                {
                    partOneRev.Advance = partOneRev.Total;
                }
                return partOneRev;
            }
            catch (System.Exception ex)
            {
                return new PartOneRev();
               // throw  new Exception(typeof(T).FullName);
            }
            
        }
    }
}
