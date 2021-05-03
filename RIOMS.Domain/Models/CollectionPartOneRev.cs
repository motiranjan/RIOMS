namespace RIOMS.Domain.Models
{
    public class CollectionPartOneRev : PartOneRev
    {

        public int ReceiptNo { get; set; }
      

    }
    public partial class CollectionCess : CollectionPartOneRev
    {
        public virtual Receipt Receipt { get; set; }
    }
    public partial class CollectionWaterTax : CollectionPartOneRev

    {
        public virtual Receipt Receipt { get; set; }
    }
    public partial class CollectionLandRevenue : CollectionPartOneRev
    {
        public virtual Receipt Receipt { get; set; }
    }

    public partial class VillageWiseTahCollectionCess : PartOneRev
    {

        public int VillageId { get; set; }

        public string Year { get; set; }

    }
    public partial class VillageWiseTahCollectionLandRevenue : PartOneRev

    {
        public int VillageId { get; set; }

        public string Year { get; set; }
    }
    public partial class VillageWiseTahCollectionWaterTax : PartOneRev
    {
        public int VillageId { get; set; }

        public string Year { get; set; }
    }

}