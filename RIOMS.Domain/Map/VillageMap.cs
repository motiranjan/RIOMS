using RIOMS.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
namespace RIOMS.Domain.Map
{
    public class VillageMap : EntityTypeConfiguration<Village>
    {
        public VillageMap()
        {
            this.ToTable("Villages");
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.HasMany(t => t.Khatas).WithRequired(t => t.Village).HasForeignKey(t => t.VillageId);
            this.HasMany(t => t.Plots).WithRequired(t => t.Village).HasForeignKey(t => t.VillageId);
            this.HasRequired(t => t.RICircle).WithMany(t => t.Villages).HasForeignKey(t => t.RICircleId);
            this.HasRequired(t => t.Tahasil).WithMany(t => t.Villages).HasForeignKey(t => t.TahId);
            this.HasMany(t => t.CollectionMovementCessesFrom).WithRequired(t => t.ToVillage).HasForeignKey(t => t.ToVillageId);
            this.HasMany(t => t.CollectionMovementCessesTo).WithRequired(t => t.FromVillage).HasForeignKey(t => t.FromVillageId);
            this.HasMany(t => t.CollectionMovementLandRevenuesFrom).WithRequired(t => t.ToVillage).HasForeignKey(t => t.ToVillageId);
            this.HasMany(t => t.CollectionMovementLandRevenuesTo).WithRequired(t => t.FromVillage).HasForeignKey(t => t.FromVillageId);
            this.HasMany(t => t.CollectionMovementCessesFrom).WithRequired(t => t.ToVillage).HasForeignKey(t => t.ToVillageId);
            this.HasMany(t => t.CollectionMovementCessesTo).WithRequired(t => t.FromVillage).HasForeignKey(t => t.FromVillageId);
            this.HasMany(t => t.VillageWiseDemandCesses).WithRequired(t => t.Village).HasForeignKey(t => t.VillageId);
            this.HasMany(t => t.VillageWiseDemandLandRevenues).WithRequired(t => t.Village).HasForeignKey(t => t.VillageId);
            this.HasMany(t => t.VillageWiseDemandWaterTaxes).WithRequired(t => t.Village).HasForeignKey(t => t.VillageId);
            this.HasMany(t => t.IncreaseInDemandCesses).WithRequired(t => t.Village).HasForeignKey(t => t.VillageId);
            this.HasMany(t => t.IncreaseInDemandLandrevenues).WithRequired(t => t.Village).HasForeignKey(t => t.VillageId);
            this.HasMany(t => t.DemandCesses).WithRequired().HasForeignKey(t => t.VillageId);
            this.HasMany(t => t.DemandLandRevenues).WithRequired().HasForeignKey(t => t.VillageId);
            this.HasMany(t => t.DemandWaterTaxes).WithRequired().HasForeignKey(t => t.VillageId);
            this.HasMany(t => t.TahCollectionLandRevenues).WithRequired().HasForeignKey(t => t.VillageId);
            this.HasMany(t => t.TahCollectionWaterTaxes).WithRequired().HasForeignKey(t => t.VillageId);
            this.HasMany(t => t.TahCollectionCesses).WithRequired().HasForeignKey(t => t.VillageId);
            this.HasMany(t => t.DemandMiscRevenues).WithRequired().HasForeignKey(t => t.VillageId);
            this.HasMany(t => t.MiscRevenues).WithRequired().HasForeignKey(t => t.VillageId);
        }
    }
}
