namespace RIOMS.Domain.Models
{
    using System;
    
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public  class TahReceipt
    {

        public TahReceipt()
        {
            //CollectionCess = new TahCollectionCess();
            //CollectionLandRevenue = new TahCollectionLandRevenue();
            //CollectionWaterTax = new TahCollectionWaterTax();
        }
        public string ReceiptNo { get; set; }

        public int VillageId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

     
        public string Year { get; set; }

       
        public string KhataNo { get; set; }

        public int? MIscId { get; set; }

        public virtual MiscRevenue MiscRevenue { get; set; }

        public virtual TahCollectionCess CollectionCess { get; set; }

        public virtual TahCollectionLandRevenue CollectionLandRevenue { get; set; }

        public virtual TahCollectionMiscRevenue CollectionMiscRevenue { get; set; }

        public virtual TahCollectionWaterTax CollectionWaterTax { get; set; }
        public virtual Khata Khata { get; set; }
    }
}
