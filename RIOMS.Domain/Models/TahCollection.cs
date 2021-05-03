namespace RIOMS.Domain.Models
{
    public partial class TahCollectionCess : PartOneRev
    {
        public string ReceiptNo { get; set; }
       
        public virtual TahReceipt TahReceipt { get; set; }
    }
    public partial class TahCollectionLandRevenue : PartOneRev

    {
        public string ReceiptNo { get; set; }
       
        public virtual TahReceipt TahReceipt { get; set; }
    }
    public partial class TahCollectionWaterTax : PartOneRev
    {
        public string ReceiptNo { get; set; }
       
        public virtual TahReceipt TahReceipt { get; set; }
    }
}
