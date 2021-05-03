using RIOMS.Domain.Abstract;
using RIOMS.Domain.Models;
using RIOMS.WebUI.Models;
using System.Web.Mvc;

namespace RIOMS.WebUI.Controllers
{
    public class CashBookController : Controller
    {
        // GET: /CashBook/
        private IRIOMSRepository repository;

        public CashBookController(IRIOMSRepository RIOMSRepository)
        {
            this.repository = RIOMSRepository;
        }

        public ViewResult Index(string year, int iformNo)
        {
            IForm iform = repository.GetIform(year, iformNo);
            ReceiptViewModel viewModel = new ReceiptViewModel(repository.GetReceiptsByIForm(iform));
            ViewBag.DepositeDate = iform.DepositeDate;
            return View(viewModel);
        }
    }
}