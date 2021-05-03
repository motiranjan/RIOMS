using RIOMS.Domain.Abstract;
using RIOMS.Domain.Models;
using RIOMS.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RIOMS.WebUI.Controllers
{
    public class VillageWariController : Controller
    {
        // GET: /VillageWari/
        private IRIOMSRepository repository;

        public VillageWariController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }

        public ViewResult Index(string year)
        {
            ViewBag.Villages = repository.Villages.Where(v => v.RICircleId == Util.Util.RICId).ToList();
            ViewBag.Year = year;
            return View(repository.IForms.Where(i => i.Year == year));
        }

        public ViewResult detail(string year, int iformNo, int vid)
        {
            ViewBag.Village = repository.Villages.SingleOrDefault(v => v.Id == vid);
            VillageWariViewModel viewModel = new VillageWariViewModel(repository.VillageWari(vid, iformNo, year),new IForm { IFormNo=iformNo});
            return View(viewModel);
        }
        public ViewResult detailAll(string year,  int vid)
        {
            ViewBag.Village = repository.Villages.SingleOrDefault(v => v.Id == vid);
            List<IForm> iforms = repository.IForms.Where(i => i.Year == year).ToList();
            List<VillageWariViewModel> villageWariViewModels = new List<VillageWariViewModel>();
            foreach (IForm iform in iforms)
            {
                villageWariViewModels.Add(new VillageWariViewModel(repository.VillageWari(vid, iform.IFormNo, year),iform));
            }
           
            return View(villageWariViewModels);
        }
        public ViewResult Abstract(string year, int vid)
        {
            Village village = repository.GetVillageWithDCB(vid, year);
            return View(new VillageWariAbstractViewModel(repository.GetIformsVillageWise(year, vid), village));
        }

        public ViewResult Collections(string year, int vid)
        {
            IEnumerable<Receipt> receipts = repository.GetVillageWithReceipts(year, vid).Receipts.ToList();
            ViewBag.VillageName = repository.Villages.SingleOrDefault(v => v.Id == vid).Name;
            return View(new ReceiptViewModel(receipts));
        }
    }
}