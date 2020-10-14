using RIOMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIOMS.Domain.Map
{
   public class CollectionMovementCessMap : EntityTypeConfiguration<CollectionMovementCess>
    {
        public CollectionMovementCessMap()
        {
            this.HasKey(t => new { t.Id, t.Year, t.FromVillageId, t.ToVillageId, });
            this.HasRequired(t => t.ToVillage).WithMany(t => t.CollectionMovementCessesFrom).HasForeignKey(t => t.ToVillageId);
            this.HasRequired(t => t.FromVillage).WithMany(t => t.CollectionMovementCessesTo).HasForeignKey(t => t.FromVillageId);
           
        }
    }
    public class CollectionMovementMiscRevenueMap : EntityTypeConfiguration<CollectionMovementMiscRevenue>
    {
        public CollectionMovementMiscRevenueMap()
        {
            this.HasKey(t => new {t.Year, t.FromVillageId, t.ToVillageId, });
            this.HasRequired(t => t.ToVillage).WithMany(t => t.CollectionMovementMiscRevenuesFrom).HasForeignKey(t => t.ToVillageId);
            this.HasRequired(t => t.FromVillage).WithMany(t => t.CollectionMovementMiscRevenuesTo).HasForeignKey(t => t.FromVillageId);
        }
    }
}
