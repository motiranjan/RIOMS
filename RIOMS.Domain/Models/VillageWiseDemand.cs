namespace RIOMS.Domain.Models
{
    public partial class VillageWiseDemandCess : DemandPartOneRev
    {
        public Village Village { get; internal set; }
    }
    public partial class VillageWiseDemandLandRevenue : DemandPartOneRev
    {
        public Village Village { get; internal set; }
    }
    public partial class VillageWiseDemandWaterTax : DemandPartOneRev
    {
        public Village Village { get; internal set; }
    }
}