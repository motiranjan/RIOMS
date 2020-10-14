using RIOMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIOMS.Domain.Map
{
   public class CollectionMiscRevenueMap : EntityTypeConfiguration<CollectionMiscRevenue>
    {
        public CollectionMiscRevenueMap()
        {
            this.ToTable("CollectionMiscRevenues");

            this.HasRequired(t => t.MiscRevenue).WithMany(t=>t.CollectionMiscRevenues).HasForeignKey(t => t.MiscId);
        }
    }
}
