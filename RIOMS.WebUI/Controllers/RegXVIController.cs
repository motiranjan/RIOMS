using RIOMS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RIOMS.WebUI.Models;
using RIOMS.Domain;
using RIOMS.Domain.Models;

namespace RIOMS.WebUI.Controllers
{
    public class RegXVIController : Controller
    {
        private IRIOMSRepository repository;

        public RegXVIController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }

        public ViewResult PartOne(string year)
        {
            List<DCBViewModel> dcbs = new List<DCBViewModel>();
            foreach (Village village in repository.Villages.Where(v => v.RICircleId == Util.Util.RICId))
            {
                dcbs.Add(new DCBViewModel(repository.GetVillageWithDCB(village.Id, year)));
            }
            return View(new RegXVIPart1ViewModel(dcbs));
        }
        public ViewResult PartTwo(string year)
        {
            List<DCBXVI2ViewModel> dcbs = new List<DCBXVI2ViewModel>();
            foreach (Village village in repository.Villages.Where(v => v.RICircleId == Util.Util.RICId))
            {
                dcbs.Add(new DCBXVI2ViewModel(repository.GetDCBXVI2(village.Id, year)));
            }
            return View(new RegXVIPart2ViewModel(dcbs));
        }
    }
}
