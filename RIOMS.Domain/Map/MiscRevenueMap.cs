using RIOMS.Domain.Models;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.CompilerServices;

namespace RIOMS.Domain.Map
{
    class MiscRevenueMap : EntityTypeConfiguration<MiscRevenue>
    {
        public MiscRevenueMap()
        {
            this.ToTable("MiscRevenues");
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(t => t.Father_HusbandName).HasColumnName("Father/HusbandName");
            //this.HasMany(t => t.CollectionMiscRevenues).WithOptional(t => t.MiscRevenue).HasForeignKey(t => t.MiscId);
            //this.HasMany(t => t.TahCollectionMiscRevenues).WithOptional().HasForeignKey(t => t.MiscId);
            this.HasMany(t => t.Receipts).WithRequired().HasForeignKey(t => t.MiscId);
            this.HasMany(t => t.TahReceipts).WithOptional().HasForeignKey(t => t.MIscId);
            this.HasMany(t => t.DemandMiscRevenues).WithRequired().HasForeignKey(t => t.MiscId);
            this.HasRequired(t => t.Village).WithMany(t=>t.MiscRevenues).HasForeignKey(t =>t.VillageId);
            this.HasRequired(t => t.TypesOfMiscRev).WithMany(t => t.MiscRevenues).HasForeignKey(t => t.TypeId);
        }

       
    }
    public class TypeOfMiscRevMap : EntityTypeConfiguration<TypesOfMiscRev>
    {
        public TypeOfMiscRevMap()
        {
            this.ToTable("TypesOfMiscRev");
            this.HasKey(t => t.Id);

            HasMany(t => t.MiscRevenues).WithRequired(t => t.TypesOfMiscRev).HasForeignKey(t => t.TypeId);
        }
    }
    public  class VillageWiseTahCollectionMiscRevenueMap : EntityTypeConfiguration<VillageWiseTahCollectionMiscRevenue>
    {
        public VillageWiseTahCollectionMiscRevenueMap()
        {
            this.ToTable("VillageWiseTahCollectionMiscRevenue");
            this.HasKey(t => new { t.VillageId, t.Year });
            
        }
    }
    public class DemandMiscRevenueMap : EntityTypeConfiguration<DemandMiscRevenue>
    {
        public DemandMiscRevenueMap()
        {
            this.ToTable("DemandMiscRevenues");
            this.HasKey(t => new { t.MiscId, t.VillageId });
            this.HasRequired(t => t.MiscRevenue).WithMany(t => t.DemandMiscRevenues).HasForeignKey(t => t.MiscId);
        }
    }
}
