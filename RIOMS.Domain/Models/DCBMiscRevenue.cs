namespace RIOMS.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class DCBMiscRevenue
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }

        [Key]
        [Column("Father/HusbandName", Order = 2)]
        public string Father_HusbandName { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Type { get; set; }

        public int? ReceiptNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [StringLength(131)]
        public string CaseNo { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Amount { get; set; }

        public decimal? Current { get; set; }

        public decimal? Arrear { get; set; }

        public decimal? Interest { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillageId { get; set; }

        public decimal? Balance { get; set; }
    }
}
