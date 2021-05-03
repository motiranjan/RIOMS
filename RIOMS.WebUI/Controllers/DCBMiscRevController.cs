using RIOMS.Domain.Abstract;
using RIOMS.Domain.Models;
using RIOMS.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RIOMS.WebUI.Controllers
{
    public class DCBMiscRevController : Controller
    {
        //
        // GET: /DCBMisc/
        private IRIOMSRepository repository;

        public DCBMiscRevController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }
        public ViewResult Index(string year)
        {
            ViewBag.Villages = repository.Villages.Where(v => v.RICircleId == Util.Util.RICId).ToList();
            ViewBag.Year = year;
            return View();
        }
        public ViewResult Add()
        {
            ViewBag.Villages = new SelectList(repository.Villages, "Id", "Name");
            ViewBag.TypesOfMiscRev = new SelectList(repository.TypesOfMiscRev, "Id", "Name");
            return View(new MiscRevenue());
        }
        [HttpPost]
        public ActionResult Add(MiscRevenue miscRev)
        {
            if (ModelState.IsValid)
            {
                repository.SaveMiscRev(miscRev);
                return View(new MiscRevenue());
            }
            else
            {
                ViewBag.Villages = new SelectList(repository.Villages, "Id", "Name");
                ViewBag.TypesOfMiscRev = new SelectList(repository.TypesOfMiscRev, "Id", "Name");
                return View(miscRev);
            }
        }
        public ViewResult Detail(int vid, string year)
        {

            return View(repository.GetMiscRevDetail(vid, year));
        }
        public ViewResult DCB(int vid, string year)
        {
            ViewBag.VillageName = repository.Villages.SingleOrDefault(v => v.Id == vid).Name;
            //IEnumerable<DCBMiscRevenue> dcbMiscRevs=repository.GetDCBMiscRev(vid, year);
            IEnumerable<IForm> iforms = repository.GetMiscCollectionIformWise(year, vid);
            return View(new DCBMiscRevViewModel(repository.GetDCBMiscRev(vid, year)));
        }
        public ViewResult Abstract(string year)
        {
            List<DCBMiscRevViewModel> dcbMiscrevs = new List<DCBMiscRevViewModel>();
            foreach (Village village in repository.Villages.Where(v => v.RICircleId == 1))
            {
                dcbMiscrevs.Add(new DCBMiscRevViewModel(repository.GetDCBMiscRev(village.Id, year)));
            }
            return View(dcbMiscrevs);
        }
    }
}
