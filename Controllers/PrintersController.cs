using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintManager.Interfaces;
using PrintManager.ViewModels;

namespace PrintManager.Controllers
{
    [Authorize]
    public class PrintersController : Controller
    {
        private readonly IPrinterRepository _printerRepository;

        public PrintersController(IPrinterRepository printerRepository)
        {
            _printerRepository = printerRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var printers = _printerRepository.GetAll().ToList();
            return View(printers);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var printer = _printerRepository.GetAll().FirstOrDefault(p => p.Id == id);
            if (printer == null)
                return NotFound();
            return View("AddEdit", PrinterViewModel.FromPrinter(printer));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new PrinterViewModel();
            return View("AddEdit", viewModel);
        }
        [HttpPost]
        public IActionResult AddEdit(PrinterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEdit", viewModel);
            }
            var printer = viewModel.ToPrinter();
            _printerRepository.Save(printer);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var printer = _printerRepository.GetAll().FirstOrDefault(p => p.Id == id);
            if (printer == null)
                return NotFound();
            _printerRepository.Delete(printer);
            return RedirectToAction("Index");
        }
    }
}