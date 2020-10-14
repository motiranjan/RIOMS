using RIOMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIOMS.Domain.Map
{
   public class KhataMap : EntityTypeConfiguration<Khata>
    {
        public KhataMap()
        {
            this.ToTable("khatas");
            this.Property(t => t.KhataNo).HasColumnName("KhataNo");
            this.Property(t => t.VillageId).HasColumnName("VillageId");
            this.HasKey(t => new { t.VillageId, t.KhataNo });
            this.Ignore(t => t.CollectionCess);
            this.Ignore(t => t.CollectionLandRevenue);
            this.Ignore(t => t.CollectionWaterTax);
            this.Ignore(t => t.BalanceCess);
            this.Ignore(t => t.BalanceLandRevenue);
            this.Ignore(t => t.BalanceLandRevenue);
            this.HasMany(t => t.DemandCesses).WithRequired(t=>t.Khata).HasForeignKey(t => new { t.VillageId, t.KhataNo });
            this.HasMany(t => t.DemandLandRevenues).WithRequired(t => t.Khata).HasForeignKey(t => new { t.VillageId,t.KhataNo });
            this.HasMany(t => t.DemandWaterTaxes).WithRequired(t => t.Khata).HasForeignKey(t => new { t.VillageId, t.KhataNo });
            this.HasMany(t => t.Receipts).WithOptional(t => t.Khata).HasForeignKey(t=>new { t.VillageId,t.KhataNo});
        }
    }
}
