using RIOMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RIOMS.Domain.Map
{
  public  class ReceiptMap : EntityTypeConfiguration<Receipt>
    {
        public ReceiptMap()
        {
            this.ToTable("Receipts");
            this.HasKey(t => t.ReceiptNo);
            this.Property(t => t.Date).HasColumnName("Date").HasColumnType("date");
            this.HasOptional(t => t.CollectionCess).WithRequired(t => t.Receipt);
            this.HasOptional(t => t.CollectionLandRevenue).WithRequired(t => t.Receipt);
            this.HasOptional(t => t.CollectionMiscRevenue).WithRequired(t => t.Receipt);
            this.HasOptional(t => t.CollectionOLR).WithRequired(t => t.Receipt);
            this.HasOptional(t => t.CollectionWaterTax).WithRequired(t => t.Receipt);
            this.HasOptional(t => t.CollectionOther).WithRequired(t => t.Receipt);
            this.HasOptional(t => t.CollectionOPDR).WithRequired(t => t.Receipt);

            
        }
    }
}
