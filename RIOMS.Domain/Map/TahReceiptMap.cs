using RIOMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIOMS.Domain.Map
{
   public class TahReceiptMap : EntityTypeConfiguration<TahReceipt>
    {
        public TahReceiptMap()
        {
            this.ToTable("TahReceipts");
            this.HasOptional(t => t.TahCollectionCess).WithRequired(t => t.TahReceipt);
            this.HasOptional(t => t.TahCollectionMiscRevenue).WithRequired(t => t.TahReceipt);
            this.HasOptional(t => t.TahCollectionWaterTax).WithRequired(t => t.TahReceipt);
            this.HasOptional(t => t.TahCollectionLandRevenue).WithRequired(t => t.TahReceipt);
        }
    }
}
