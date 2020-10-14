using RIOMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIOMS.Domain.Map
{
   public class CollectionCessMap: EntityTypeConfiguration<CollectionCess>
    {
        public CollectionCessMap()
        {
            this.Map(t => t.MapInheritedProperties());
            this.ToTable("CollectionCesses");
            
            this.HasKey(t => t.ReceiptNo);
            this.HasRequired(t => t.Receipt).WithOptional(t => t.CollectionCess);
            this.Ignore(t => t.Advance);
        }
    }
    public class CollectionWaterTaxMap : EntityTypeConfiguration<CollectionWaterTax>
    {
        public CollectionWaterTaxMap()
        {
            this.Map(t => t.MapInheritedProperties());
            this.ToTable("CollectionWaterTaxes");
            this.HasKey(t => t.ReceiptNo);
            this.HasRequired(t => t.Receipt).WithOptional(t => t.CollectionWaterTax);
            this.Ignore(t => t.Advance);
        }
    }
    public class CollectionLandRevenueMap : EntityTypeConfiguration<CollectionLandRevenue>
    {
        public CollectionLandRevenueMap()
        {
            this.Map(t => t.MapInheritedProperties());
            this.ToTable("CollectionLandRevenues");
            this.HasKey(t => t.ReceiptNo);
            this.HasRequired(t => t.Receipt).WithOptional(t => t.CollectionLandRevenue);
            this.Ignore(t => t.Advance);
        }
    }
}
