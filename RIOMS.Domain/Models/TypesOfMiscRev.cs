namespace RIOMS.Domain.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

  
    public partial class TypesOfMiscRev
    {

        public TypesOfMiscRev()
        {
            MiscRevenues = new HashSet<MiscRevenue>();
        }

        public int Id { get; set; }

       
        public string Name { get; set; }


        public virtual ICollection<MiscRevenue> MiscRevenues { get; set; }
    }
}
