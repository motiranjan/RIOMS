using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RIOMS.Domain
{
   public class KhataWithArea
    {
        public string KhataNo { get; set; }

        public decimal? TotalCultivableArear { get { return MalArea.GetValueOrDefault() + BahalArea.GetValueOrDefault(); } }
        public decimal? TotalArea { get; set; }

        public decimal? MalArea { get; set; }
        public decimal? BahalArea { get; set; }
        public string NameOfRT { get; set; }
    }
}
