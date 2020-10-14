using RIOMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIOMS.Domain.Map
{
    class MiscRevenueMap: EntityTypeConfiguration<MiscRevenue>
    {
        public MiscRevenueMap()
        {
            this.ToTable("MiscRevenues");
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
           this.HasMany(t => t.Receipts).WithOptional(t => t.MiscRevenue).HasForeignKey(t => t.MiscId);
        }
    }
}
