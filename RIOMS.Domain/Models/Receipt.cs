namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Receipt
    {
      
        public int ReceiptNo { get; set; }

        public string KhataNo { get; set; }

      
        public string Year { get; set; }

        public int? VillageId { get; set; }

      
        public DateTime Date { get; set; }

        public string NameOfRT { get; set; }

        public bool IsCanceled { get; set; }

        public int? ActualVillageId { get; set; }

        public int? MiscId { get; set; }

        public int? BookNo { get; set; }

        public virtual CollectionCess CollectionCess { get; set; }

        public virtual CollectionLandRevenue CollectionLandRevenue { get; set; }

        public virtual CollectionMiscRevenue CollectionMiscRevenue { get; set; }

        public virtual CollectionOLR CollectionOLR { get; set; }

        public virtual CollectionOPDR CollectionOPDR { get; set; }

        public virtual CollectionOther CollectionOther { get; set; }

        public virtual CollectionWaterTax CollectionWaterTax { get; set; }

        public virtual Village Village { get; set; }
        public virtual Khata Khata { get; set; }

        public virtual MiscRevenue MiscRevenue { get; set; }
    }
}
