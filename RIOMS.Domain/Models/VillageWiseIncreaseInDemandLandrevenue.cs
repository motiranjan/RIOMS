namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("VillageWiseIncreaseInDemandLandrevenue")]
    public partial class VillageWiseIncreaseInDemandLandrevenue : DemandPartOneRev
    {

        public virtual Village Village { get; internal set; }
    }
}
