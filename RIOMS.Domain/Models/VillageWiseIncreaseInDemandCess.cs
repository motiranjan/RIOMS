namespace RIOMS.Domain.Models
{
    public partial class VillageWiseIncreaseInDemandCess : DemandPartOneRev
    {

        public virtual Village Village { get; internal set; }
    }
}
