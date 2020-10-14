namespace RIOMS.Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypesOfMiscRev")]
    public partial class TypesOfMiscRev
    {
       
        public TypesOfMiscRev()
        {
            MiscRevenues = new HashSet<MiscRevenue>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       
        public virtual ICollection<MiscRevenue> MiscRevenues { get; set; }
    }
}
