using RIOMS.Domain.Abstract;
using RIOMS.Domain.Models;
using RIOMS.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace RIOMS.WebUI.Controllers
{
    public class IFormsController : Controller
    {
        private IRIOMSRepository repository;

        public IFormsController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }
        // GET: /IForms/
        [HttpPost]
        public ActionResult GenerateIForm(IForm iForm)
        {
            ViewBag.Villages = repository.Villages;
            iForm.Year = System.Configuration.ConfigurationManager.AppSettings["Year"].ToString();
            if (repository.AddIform(iForm))
            {
                return View("Detail", repository.GetIform(iForm.Year, iForm.IFormNo));
            }
            return View("Detail", repository.GetIform(iForm.Year, iForm.IFormNo));
        }

        public ViewResult AnnualAbstract()
        {
            return View("GenerateIForm", new IFormViewModel(repository.GetAllReceipt(), new IForm()));
        }
        public ViewResult index(string year)
        {

            return View(repository.IForms.Where(i => i.Year == year));
        }
        public ViewResult Create()
        {

            return View(new IForm());
        }
        public ViewResult Detail(string year, int iformNo)
        {
            ViewBag.Villages = repository.Villages;

            return View(repository.GetIform(year, iformNo));
        }
        public ViewResult List()
        {
            ViewBag.Villages = repository.Villages;
            return View(repository.IForms);
        }
        public ViewResult Abstract(string year)
        {
            return View(repository.GetAllIForms(year));
        }
    }
}
