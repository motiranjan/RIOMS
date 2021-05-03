using RIOMS.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RIOMS.Domain.Map
{
    public class DemandCessMap : EntityTypeConfiguration<DemandCess>
    {
        public DemandCessMap()
        {
            this.ToTable("DemandCesses");
            this.HasKey(t => new { t.VillageId, t.KhataNo, t.Year });
            this.Ignore(t => t.InterestTotal);
        }
    }
    public class DemandLandRevenueMap : EntityTypeConfiguration<DemandLandRevenue>
    {
        public DemandLandRevenueMap()
        {
            this.ToTable("DemandLandRevenues");
            this.HasKey(t => new { t.VillageId, t.KhataNo, t.Year });
            this.Ignore(t => t.InterestTotal);
        }
    }
    public class DemandWaterTaxMap : EntityTypeConfiguration<DemandWaterTax>
    {
        public DemandWaterTaxMap()
        {
            this.ToTable("DemandWaterTaxes");
            this.HasKey(t => new { t.VillageId, t.KhataNo, t.Year });
            this.Ignore(t => t.InterestTotal);
        }
    }
    public class VillageWiseDemandCessMap : EntityTypeConfiguration<VillageWiseDemandCess>
    {
        public VillageWiseDemandCessMap()
        {
            this.ToTable("VillageWiseDemandCess");
            this.HasKey(t => new { t.VillageId, t.Year });
            this.Ignore(t => t.InterestTotal);
        }
    }
    public class VillageWiseDemandLandRevenueMap : EntityTypeConfiguration<VillageWiseDemandLandRevenue>
    {
        public VillageWiseDemandLandRevenueMap()
        {
            this.ToTable("VillageWiseDemandLandRevenue");
            this.HasKey(t => new { t.VillageId, t.Year });
            this.Ignore(t => t.InterestTotal);
        }
    }
    public class VillageWiseDemandWaterTaxMap : EntityTypeConfiguration<VillageWiseDemandWaterTax>
    {
        public VillageWiseDemandWaterTaxMap()
        {
            this.ToTable("VillageWiseDemandWaterTax");
            this.HasKey(t => new { t.VillageId, t.Year });
            this.Ignore(t => t.InterestTotal);
        }
    }

    public class VillageWiseIncreaseInDemandCessMap : EntityTypeConfiguration<VillageWiseIncreaseInDemandCess>
    {
        public VillageWiseIncreaseInDemandCessMap()
        {
            this.ToTable("VillageWiseIncreaseInDemandCesses");
            this.HasKey(t => new { t.VillageId, t.Year });
            this.Ignore(t => t.Advance);
            this.Ignore(t => t.InterestTotal);
        }
    }

    public class VillageWiseIncreaseInDemandLandrevenueMap : EntityTypeConfiguration<VillageWiseIncreaseInDemandLandrevenue>
    {
        public VillageWiseIncreaseInDemandLandrevenueMap()
        {
            this.ToTable("VillageWiseIncreaseInDemandLandrevenues");
            this.HasKey(t => new { t.VillageId, t.Year });
            this.Ignore(t => t.Advance);
            this.Ignore(t => t.InterestTotal);
        }
    }

 
}

