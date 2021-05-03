using RIOMS.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RIOMS.Domain.Map
{
    public class CollectionMiscRevenueMap : EntityTypeConfiguration<CollectionMiscRevenue>
    {
        public CollectionMiscRevenueMap()
        {
            this.ToTable("CollectionMiscRevenues");

            //this.HasRequired(t => t.MiscRevenue).WithMany(t => t.CollectionMiscRevenues).HasForeignKey(t => t.MiscId);
        }
    }
    public class TahCollectionMiscRevenueMap : EntityTypeConfiguration<TahCollectionMiscRevenue>
    {
        public TahCollectionMiscRevenueMap()
        {
            this.ToTable("TahCollectionMiscRevenues");

            this.HasKey(t => t.ReceiptNo);
        }
    }
}
