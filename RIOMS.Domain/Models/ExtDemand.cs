using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RIOMS.Domain.Models
{
    public class Abc
    {
        public int xyz
        {
            get;
            set;
        }
    }
    public partial class DemandCess
    {
        public static DemandCess operator +(DemandCess r1, DemandCess r2)
        {
            return new DemandCess
            {
                Current = r1.Current + r2.Current,
                Previous = r1.Previous + r2.Previous,
                Second = r1.Second + r2.Second,
                Third = r1.Third + r2.Third,
                MoreThanThree = r1.MoreThanThree + r2.MoreThanThree
            };
        }
        public static DemandCess operator -(DemandCess r1, DemandCess r2)
        {
            return new DemandCess
            {
                Current = r1.Current - r2.Current,
                Previous = r1.Previous - r2.Previous,
                Second = r1.Second - r2.Second,
                Third = r1.Third - r2.Third,
                MoreThanThree = r1.MoreThanThree - r2.MoreThanThree
            };
        }
        public Decimal Arrear
        {
            get
            {
                return MoreThanThree + Third + Second + Previous;
            }
        }
    }
    public partial class DemandWaterTax
    {
        public static DemandWaterTax operator +(DemandWaterTax r1, DemandWaterTax r2)
        {
            return new DemandWaterTax
            {
                Current = r1.Current + r2.Current,
                Previous = r1.Previous + r2.Previous,
                Second = r1.Second + r2.Second,
                Third = r1.Third + r2.Third,
                MoreThanThree = r1.MoreThanThree + r2.MoreThanThree
            };
        }
        public static DemandWaterTax operator -(DemandWaterTax r1, DemandWaterTax r2)
        {
            return new DemandWaterTax
            {
                Current = r1.Current - r2.Current,
                Previous = r1.Previous - r2.Previous,
                Second = r1.Second - r2.Second,
                Third = r1.Third - r2.Third,
                MoreThanThree = r1.MoreThanThree - r2.MoreThanThree
            };
        }
        public Decimal Arrear
        {
            get
            {
                return MoreThanThree + Third + Second + Previous;
            }
        }
    }

    public partial class DemandLandRevenue
    {
        public static DemandLandRevenue operator +(DemandLandRevenue r1, DemandLandRevenue r2)
        {
            return new DemandLandRevenue
            {
                Current = r1.Current + r2.Current,
                Previous = r1.Previous + r2.Previous,
                Second = r1.Second + r2.Second,
                Third = r1.Third + r2.Third,
                MoreThanThree = r1.MoreThanThree + r2.MoreThanThree
            };
        }
        public static DemandLandRevenue operator -(DemandLandRevenue r1, DemandLandRevenue r2)
        {
            return new DemandLandRevenue
            {
                Current = r1.Current - r2.Current,
                Previous = r1.Previous - r2.Previous,
                Second = r1.Second - r2.Second,
                Third = r1.Third - r2.Third,
                MoreThanThree = r1.MoreThanThree - r2.MoreThanThree
            };
        }
        public Decimal Arrear
        {
            get
            {
                return MoreThanThree + Third + Second + Previous;
            }
        }
    } 
    public partial class VillageWiseDemandCess
    {
        public Decimal Arrear
        {
            get
            {
                return MoreThanThree + Third + Second + Previous;
            }
        }
    }
    public partial class VillageWiseDemandWaterTax
    {
        public Decimal Arrear
        {
            get
            {
                return MoreThanThree + Third + Second + Previous;
            }
        }
    }

}
