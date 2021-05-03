namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Farmer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Father_HusbandName { get; set; }

        [Key]
        [Column(Order = 3)]
        public string BankId { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AcNo { get; set; }
    }
}
