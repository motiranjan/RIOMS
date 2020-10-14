using RIOMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIOMS.Domain.Map
{
  public  class PlotMap : EntityTypeConfiguration<Plot>
    {
        public PlotMap()
        {
            this.ToTable("PlotDetails");
            this.HasKey(t => new { t.VillageId, t.KhataNo,  t.PlotNo });
            this.HasRequired(t => t.Khata).WithMany(t => t.Plots).HasForeignKey(t=>new {t.VillageId,t.KhataNo });
            this.HasRequired(t => t.Village).WithMany(t => t.Plots).HasForeignKey(t => t.VillageId);
        }
    }
}
