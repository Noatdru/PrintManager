using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintManager.Interfaces;
using PrintManager.ViewModels;

namespace PrintManager.Controllers
{
    [Authorize]
    public class ScannersController : Controller
    {
        private readonly IScannerRepository _scannerRepository;

        public ScannersController(IScannerRepository scannerRepository)
        {
            _scannerRepository = scannerRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var scanners = _scannerRepository.GetAll().ToList();
            return View(scanners);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var scanner = _scannerRepository.GetAll().FirstOrDefault(p => p.Id == id);
            if (scanner == null)
                return NotFound();
            return View("AddEdit", ScannerViewModel.FromScanner(scanner));
        }
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ScannerViewModel();
            return View("AddEdit", viewModel);
        }
        [HttpPost]
        public IActionResult AddEdit(ScannerViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEdit", viewModel);
            }
            var scanner = viewModel.ToScanner();
            _scannerRepository.Save(scanner);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var scanner = _scannerRepository.GetAll().FirstOrDefault(s => s.Id == id);
            if (scanner == null)
                return NotFound();
            _scannerRepository.Delete(scanner);
            return RedirectToAction("Index");
        }
    }
}