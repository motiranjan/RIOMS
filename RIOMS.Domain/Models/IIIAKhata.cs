namespace RIOMS.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class IIIAKhata
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string KhataNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillageId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Year { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal OldRent { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal OldCess { get; set; }

        public int? RM_Is_No { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RM_Is_Date { get; set; }
    }
}
