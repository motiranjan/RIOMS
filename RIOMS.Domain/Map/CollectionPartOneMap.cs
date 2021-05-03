using RIOMS.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RIOMS.Domain.Map
{
    public class CollectionCessMap : EntityTypeConfiguration<CollectionCess>
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

    public class AdvanceCollectionCessMap : EntityTypeConfiguration<AdvanceCollectionCess>
    {
        public AdvanceCollectionCessMap()
        {
            this.ToTable("AdvanceCollectionCesses");
            this.HasKey(t => new { t.VillageId, t.KhataNo, t.Year });
            this.Ignore(t => t.Advance);
            this.Ignore(t => t.InterestTotal);
        }
    }
    public class AdvanceCollectionLandRevenueMap : EntityTypeConfiguration<AdvanceCollectionLandRevenue>
    {
        public AdvanceCollectionLandRevenueMap()
        {
            this.ToTable("AdvanceCollectionLandRevenues");
            this.HasKey(t => new { t.VillageId, t.KhataNo, t.Year });
            this.Ignore(t => t.Advance);
            this.Ignore(t => t.InterestTotal);
        }
    }
    public class AdvanceCollectionWaterTaxMap : EntityTypeConfiguration<AdvanceCollectionWaterTax>
    {
        public AdvanceCollectionWaterTaxMap()
        {
            this.ToTable("AdvanceCollectionWaterTaxes");
            this.HasKey(t => new { t.VillageId, t.KhataNo, t.Year });
            this.Ignore(t => t.Advance);
            this.Ignore(t => t.InterestTotal);
        }
    }

    public class TahCollectionCessMap : EntityTypeConfiguration<TahCollectionCess>
    {
        public TahCollectionCessMap()
        {
            this.Map(t => t.MapInheritedProperties());
            this.ToTable("TahCollectionCesses");

            this.HasKey(t => t.ReceiptNo);
            this.HasRequired(t => t.TahReceipt).WithOptional(t => t.CollectionCess);
            this.Ignore(t => t.Advance);
        }
    }
    public class TahCollectionWaterTaxMap : EntityTypeConfiguration<TahCollectionWaterTax>
    {
        public TahCollectionWaterTaxMap()
        {
            this.Map(t => t.MapInheritedProperties());
            this.ToTable("TahCollectionWaterTaxes");
            this.HasKey(t => t.ReceiptNo);
           this.HasRequired(t => t.TahReceipt).WithOptional(t => t.CollectionWaterTax);
            this.Ignore(t => t.Advance);
        }
    }
    public class TahCollectionLandRevenueMap : EntityTypeConfiguration<TahCollectionLandRevenue>
    {
        public TahCollectionLandRevenueMap()
        {
            this.Map(t => t.MapInheritedProperties());
            this.ToTable("TahCollectionLandRevenues");
            
            this.HasKey(t => t.ReceiptNo);
            this.HasRequired(t => t.TahReceipt).WithOptional(t => t.CollectionLandRevenue);
            this.Ignore(t => t.Advance);
        }
    }

    public class VillageWiseTahCollectionCessMap : EntityTypeConfiguration<VillageWiseTahCollectionCess>
    {
        public VillageWiseTahCollectionCessMap()
        {
          
            this.ToTable("VillageWiseTahCollectionCesses");
            //this.Map(t => t.MapInheritedProperties());
            this.HasKey(t => new {t.VillageId,t.Year });
           
            this.Ignore(t => t.Advance);
        }
    }
    public class VillageWiseTahCollectionLandRevenueMap : EntityTypeConfiguration<VillageWiseTahCollectionLandRevenue>
    {
        public VillageWiseTahCollectionLandRevenueMap()
        {
          
            this.ToTable("VillageWiseTahCollectionLandRevenues");
            //this.Map(t => t.MapInheritedProperties());
            this.HasKey(t => new { t.VillageId, t.Year });

            this.Ignore(t => t.Advance);
        }
    }
    public class VillageWiseTahCollectionWaterTaxMap : EntityTypeConfiguration<VillageWiseTahCollectionWaterTax>
    {
        public VillageWiseTahCollectionWaterTaxMap()
        {
            
            this.ToTable("VillageWiseTahCollectionWaterTaxes");
           // this.Map(t => t.MapInheritedProperties());
            this.HasKey(t => new { t.VillageId, t.Year });

            this.Ignore(t => t.Advance);
        }
    }
}
