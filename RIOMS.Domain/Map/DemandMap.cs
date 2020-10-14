using RIOMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIOMS.Domain.Map
{
    public class DemandCessMap : EntityTypeConfiguration<DemandCess>
    {
        public DemandCessMap()
        {
            this.ToTable("DemandCesses");
            this.HasKey(t => new { t.VillageId, t.KhataNo, t.Year });
        }
    }
    public class DemandLandRevenueMap : EntityTypeConfiguration<DemandLandRevenue>
    {
        public DemandLandRevenueMap()
        {
            this.ToTable("DemandLandRevenues");
            this.HasKey(t => new { t.VillageId, t.KhataNo, t.Year });
        }
    }
    public class DemandWaterTaxMap : EntityTypeConfiguration<DemandWaterTax>
    {
        public DemandWaterTaxMap()
        {
            this.ToTable("DemandWaterTaxes");
            this.HasKey(t => new { t.VillageId, t.KhataNo, t.Year });
        }
    }
}

