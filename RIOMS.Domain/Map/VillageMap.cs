using RIOMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
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
            this.HasMany(t => t.CollectionMovementCessesFrom).WithRequired(t=>t.ToVillage).HasForeignKey(t => t.ToVillageId);
            this.HasMany(t => t.CollectionMovementCessesTo).WithRequired(t=>t.FromVillage).HasForeignKey(t => t.FromVillageId);
        }
    }
}
