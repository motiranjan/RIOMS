using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RIOMS.Domain
{
    public class PartOneRev
    {
        public decimal Current { get; set; }
        public decimal Previous { get; set; }
        public decimal Second { get; set; }
        public decimal Third { get; set; }
        public decimal MoreThanThree { get; set; }
        public decimal Advance { get; set; }

        public decimal Total
        {
            get
            {
                return MoreThanThree + Third + Second + Previous + Current;
            }

        }
        public decimal Arrear
        {
            get
            {
                return MoreThanThree + Third + Second + Previous;
            }

        }
       
    }
}
