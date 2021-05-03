using RIOMS.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RIOMS.Domain.Map
{
    public class CollectionMovementCessMap : EntityTypeConfiguration<CollectionMovementCess>
    {
        public CollectionMovementCessMap()
        {
            this.Ignore(t => t.Advance);
            this.Ignore(t => t.InterestTotal);
            this.HasKey(t => new { t.Id, t.Year, t.FromVillageId, t.ToVillageId, });
            this.HasRequired(t => t.ToVillage).WithMany(t => t.CollectionMovementCessesFrom).HasForeignKey(t => t.ToVillageId);
            this.HasRequired(t => t.FromVillage).WithMany(t => t.CollectionMovementCessesTo).HasForeignKey(t => t.FromVillageId);

        }
    }
    public class CollectionMovementMiscRevenueMap : EntityTypeConfiguration<CollectionMovementMiscRevenue>
    {
        public CollectionMovementMiscRevenueMap()
        {

            this.HasKey(t => new { t.Year, t.FromVillageId, t.ToVillageId, });
            this.HasRequired(t => t.ToVillage).WithMany(t => t.CollectionMovementMiscRevenuesFrom).HasForeignKey(t => t.ToVillageId);
            this.HasRequired(t => t.FromVillage).WithMany(t => t.CollectionMovementMiscRevenuesTo).HasForeignKey(t => t.FromVillageId);
        }
    }
}
