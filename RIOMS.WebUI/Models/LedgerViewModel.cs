using RIOMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIOMS.WebUI.Models
{
    public class LedgerViewModel
    {
        List<DemandCess> demands;
        public LedgerViewModel(IEnumerable<DemandCess> argdemand)
        {
            demands = argdemand.ToList();
        }
        public List<DemandCess> DemandCess
        {
            get
            {
                return demands;
            }
        }


    }
}