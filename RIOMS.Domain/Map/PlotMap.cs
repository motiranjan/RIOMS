using RIOMS.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RIOMS.Domain.Map
{
    public class PlotMap : EntityTypeConfiguration<Plot>
    {
        public PlotMap()
        {
            this.ToTable("PlotDetails");
            this.HasKey(t => new { t.VillageId, t.KhataNo, t.PlotNo });
            this.HasRequired(t => t.Khata).WithMany(t => t.Plots).HasForeignKey(t => new { t.VillageId, t.KhataNo });
            this.HasRequired(t => t.Village).WithMany(t => t.Plots).HasForeignKey(t => t.VillageId);
        }
    }
}
