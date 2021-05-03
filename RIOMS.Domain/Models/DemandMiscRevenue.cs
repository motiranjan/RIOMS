namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class DemandMiscRevenue
    {
        public decimal Current { get; set; }

        public decimal Arrear { get; set; }

      
        public int MiscId { get; set; }

      
        public string Year { get; set; }

    
        public int VillageId { get; set; }

        public virtual MiscRevenue MiscRevenue { get; set; }



    }
}
