namespace RIOMS.Domain.Models
{
    public partial class AdvanceCollectionPartOneRev : PartOneRev
    {
        public string Year { get; set; }
        public int VillageId { get; set; }
        public string KhataNo { get; set; }
        public new decimal? Advance
        {
            get
            {
                return Total;
            }
        }
    }
    public partial class AdvanceCollectionWaterTax : AdvanceCollectionPartOneRev
    {
    }
    public partial class AdvanceCollectionLandRevenue : AdvanceCollectionPartOneRev
    {
    }
    public partial class AdvanceCollectionCess : AdvanceCollectionPartOneRev
    {
    }
}
