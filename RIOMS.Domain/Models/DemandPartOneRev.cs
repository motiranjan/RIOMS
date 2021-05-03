

namespace RIOMS.Domain.Models
{
    public class DemandPartOneRev : PartOneRev
    {

        public string Year { get; set; }
        public int VillageId { get; set; }
        //public decimal? Remission { get; set; }
        //public decimal? Increase { get; set; }
        //public decimal? Advance { get; set; }
    }
    public  class DemandCess : DemandPartOneRev
    {
        public string KhataNo { get; set; }
        public decimal? Annual { get; set; }
        public virtual Khata Khata { get; set; }
    }
    public partial class DemandLandRevenue : DemandPartOneRev
    {
        public string KhataNo { get; set; }
        public decimal? Annual { get; set; }
        public virtual Khata Khata { get; set; }
    }
    public partial class DemandWaterTax : DemandPartOneRev
    {
        public string KhataNo { get; set; }
        public decimal? Annual { get; set; }
        public virtual Khata Khata { get; set; }
    }
}
