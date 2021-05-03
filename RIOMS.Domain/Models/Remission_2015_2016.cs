namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Remission_2015-2016")]
    public partial class Remission_2015_2016
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillageId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string KhataNo { get; set; }

        public decimal? TotalArea { get; set; }

        [Column("Name of the RT")]
        public string Name_of_the_RT { get; set; }

        [Column("Annual Cess")]
        public decimal? Annual_Cess { get; set; }

        [Key]
        [Column("Annual C.B.W.R.", Order = 2)]
        public decimal Annual_C_B_W_R_ { get; set; }

        [Column("Remission amount 50 % of Cess", TypeName = "numeric")]
        public decimal? Remission_amount_50___of_Cess { get; set; }

        [Column("Balance Cess demand", TypeName = "numeric")]
        public decimal? Balance_Cess_demand { get; set; }

        [Key]
        [Column("Remission amount 100 % of C.B.W.R.", Order = 3)]
        public decimal Remission_amount_100___of_C_B_W_R_ { get; set; }
    }
}
