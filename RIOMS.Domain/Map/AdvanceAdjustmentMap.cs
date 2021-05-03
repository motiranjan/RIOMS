using RIOMS.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RIOMS.Domain.Map
{
    public class AdvanceAdjustmentCessMap : EntityTypeConfiguration<AdvanceAdjustmentCess>
    {
        public AdvanceAdjustmentCessMap()
        {
            this.ToTable("AdvanceAdjustmentCesses");
            this.HasKey(t => new { t.VillageId, t.KhataNo, t.Year });
            this.Ignore(t => t.Advance);
            this.Ignore(t => t.InterestTotal);
        }
    }
    public class AdvanceAdjustmentLandRevenueMap : EntityTypeConfiguration<AdvanceAdjustmentLandRevenue>
    {
        public AdvanceAdjustmentLandRevenueMap()
        {
            this.ToTable("AdvanceAdjustmentLandRevenues");
            this.HasKey(t => new { t.VillageId, t.KhataNo, t.Year });
            this.Ignore(t => t.Advance);
            this.Ignore(t => t.InterestTotal);
        }
    }
    public class AdvanceAdjustmentWaterTaxMap : EntityTypeConfiguration<AdvanceAdjustmentWaterTax>
    {
        public AdvanceAdjustmentWaterTaxMap()
        {
            this.ToTable("AdvanceAdjustmentWaterTaxes");
            this.HasKey(t => new { t.VillageId, t.KhataNo, t.Year });
            this.Ignore(t => t.Advance);
            this.Ignore(t => t.InterestTotal);
        }
    }
}
