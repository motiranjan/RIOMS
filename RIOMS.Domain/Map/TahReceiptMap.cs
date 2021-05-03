using RIOMS.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace RIOMS.Domain.Map
{
    public class TahReceiptMap : EntityTypeConfiguration<TahReceipt>
    {
        public TahReceiptMap()
        {
            this.ToTable("TahReceipts");
            
            this.HasKey(t=>t.ReceiptNo);
            this.Property(t => t.ReceiptNo).HasColumnName("ReceiptNo");
            this.HasOptional(t => t.CollectionCess).WithRequired(t=>t.TahReceipt);
            this.HasOptional(t => t.CollectionMiscRevenue).WithRequired(t=>t.TahReceipt);
            this.HasOptional(t => t.CollectionWaterTax).WithRequired(t=>t.TahReceipt);
            this.HasOptional(t => t.CollectionLandRevenue).WithRequired(t=>t.TahReceipt);
            this.HasOptional(t => t.MiscRevenue).WithMany(t => t.TahReceipts).HasForeignKey(t => t.MIscId);
            
        }
    }
}
