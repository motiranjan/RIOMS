namespace RIOMS.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Defaulter 
    {
        //public decimal? Area { get; set; }

        
        public string KhataNo { get; set; }

        public string NameOfRT { get; set; }

       
        public string Year { get; set; }

        public int? VillageId { get; set; }

        public CessDefaulter Cess { get; set; }
        public CBWRDefaulter CBWR { get; set; }
        public LRDefaulter LR { get; set; }
        //public decimal DFC_MoreThanThree { get; set; }

       
        //public decimal DFC_Third { get; set; }

       
        //public decimal DFC_Second { get; set; }

        
        //public decimal DFC_Previous { get; set; }

       
        //public decimal DFC_Current { get; set; }

        
        //public decimal DFW_MoreThanThree { get; set; }

       
        //public decimal DFW_Third { get; set; }

        
        //public decimal DFW_Second { get; set; }

     
        //public decimal DFW_Previous { get; set; }

        //public decimal DFW_Current { get; set; }

        //public decimal DFLR_MoreThanThree { get; set; }


        //public decimal DFLR_Third { get; set; }


        //public decimal DFLR_Second { get; set; }


        //public decimal DFLR_Previous { get; set; }

        //public decimal DFLR_Current { get; set; }
    }

    public class CessDefaulter : PartOneRev
    {
        
    }
    public class CBWRDefaulter : PartOneRev
    {
        
    }
    public class LRDefaulter : PartOneRev
    {
       
    }
}
