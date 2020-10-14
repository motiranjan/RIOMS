using RIOMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIOMS.Domain.Map
{
   public class IFormMap : EntityTypeConfiguration<IForm>
    {
        public IFormMap()
        {
            this.ToTable("IForms");
            this.HasKey(t => new { t.RICId, t.Year, t.IFormNo });
            this.HasMany(t => t.IFormDetailCesses).WithRequired(t => t.IForm).HasForeignKey(t => new { t.RICId,t.Year, t.IFormNo });
            this.HasMany(t => t.IFormDetailLandRevenues).WithRequired(t => t.IForm).HasForeignKey(t => new {t.RICId, t.Year, t.IFormNo });
            this.HasMany(t => t.IFormDetailWaterTaxes).WithRequired(t => t.IForm).HasForeignKey(t => new {t.RICId, t.Year, t.IFormNo });

            this.HasMany(t => t.IFormDetailMiscRevenues).WithRequired(t => t.IForm).HasForeignKey(t => new {t.RICId, t.Year, t.IFormNo });
            this.HasMany(t => t.IFormDetailOLRs).WithRequired(t => t.IForm).HasForeignKey(t => new { t.RICId, t.Year, t.IFormNo });
            this.HasMany(t => t.IFormDetailOthers).WithRequired(t => t.IForm).HasForeignKey(t => new { t.RICId, t.Year, t.IFormNo });
        }
    }
    public class IFormDetailCessMap : EntityTypeConfiguration<IFormDetailCess>
    {
        public IFormDetailCessMap()
        {
            this.Map(t => t.MapInheritedProperties());
            this.ToTable("IFormDetailCesses");
            this.HasKey(t => new {  t.Year, t.VillageId, t.IFormNo});
        }
    }
    public class IFormDetailLandRevenueMap : EntityTypeConfiguration<IFormDetailLandRevenue>
    {
        public IFormDetailLandRevenueMap()
        {
            this.Map(t => t.MapInheritedProperties());
            this.ToTable("IFormDetailLandRevenues");
            this.HasKey(t => new { t.Year, t.VillageId, t.IFormNo });
        }
    }
    public class IFormDetailWaterTaxMap : EntityTypeConfiguration<IFormDetailWaterTax>
    {
        public IFormDetailWaterTaxMap()
        {
            this.Map(t => t.MapInheritedProperties());
            this.ToTable("IFormDetailWaterTaxes");
            this.HasKey(t => new { t.Year, t.VillageId, t.IFormNo });
        }
    }

    public class IFormDetailMiscRevenueMap : EntityTypeConfiguration<IFormDetailMiscRevenue>
    {
        public IFormDetailMiscRevenueMap()
        {
           // this.Map(t => t.MapInheritedProperties());
            this.ToTable("IFormDetailMiscRevenues");
            this.HasKey(t => new { t.Year, t.VillageId, t.IFormNo });
        }
    }
    public class IFormDetailOLRMap : EntityTypeConfiguration<IFormDetailOLR>
    {
        public IFormDetailOLRMap()
        {
            // this.Map(t => t.MapInheritedProperties());
            this.ToTable("IFormDetailOLR");
            this.HasKey(t => new { t.Year, t.VillageId, t.IFormNo });
        }
    }
    public class IFormDetailOPDRMap : EntityTypeConfiguration<IFormDetailOPDR>
    {
        public IFormDetailOPDRMap()
        {
            // this.Map(t => t.MapInheritedProperties());
            this.ToTable("IFormDetailOPDR");
            this.HasKey(t => new { t.Year, t.VillageId, t.IFormNo });
        }
    }
    public class IFormDetailOtherMap : EntityTypeConfiguration<IFormDetailOther>
    {
        public IFormDetailOtherMap()
        {
            // this.Map(t => t.MapInheritedProperties());
            this.ToTable("IFormDetailOthers");
            this.HasKey(t => new { t.Year, t.VillageId, t.IFormNo });
        }
    }
}
