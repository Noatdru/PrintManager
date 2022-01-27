using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintManager.Interfaces;
using PrintManager.Models;
using PrintManager.ViewModels;

namespace PrintManager.Controllers
{
    [Authorize]
    public class DocumentsController : Controller
    {
        private readonly IScannerService _scannerService;
        private readonly IPrinterService _printerService;
        private readonly IPrinterRepository _printerRepository;
        private readonly IScannerRepository _scannerRepository;
        private readonly ICopierRepository _copierRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IPrintQueueRepository _printQueueRepository;

        public DocumentsController(IScannerService scannerService, IPrinterService printerService, IPrinterRepository printerRepository, IDocumentRepository documentRepository, IScannerRepository scannerRepository, ICopierRepository copierRepository, IPrintQueueRepository printQueueRepository)
        {
            _scannerService = scannerService;
            _printerService = printerService;
            _printerRepository = printerRepository;
            _documentRepository = documentRepository;
            _scannerRepository = scannerRepository;
            _copierRepository = copierRepository;
            _printQueueRepository = printQueueRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var documents = _documentRepository.GetAll();
            var viewModel = documents.Select(DocumentViewModel.FromDocument).ToList();
            return View(viewModel);
        }
        public IActionResult Scan()
        {
            var viewModel = new ScanDocumentViewModel();
            viewModel.Initialize(_scannerRepository, _copierRepository);
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Scan(ScanDocumentViewModel viewModel)
        {
            if (viewModel.ScannerId == 0)
            {
                ModelState.AddModelError("ScannerId", "Scanner is required");
                viewModel.Initialize(_scannerRepository, _copierRepository);
                return View(viewModel);
            }
            await _scannerService.ScanAsync(viewModel.ScannerId);
            return RedirectToAction("Index");
        }
        public IActionResult Print(int documentId)
        {
            var viewModel = new PrintDocumentViewModel
            {
                DocumentId = documentId
            };
            viewModel.Initialize(_printerRepository, _copierRepository);
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Print(PrintDocumentViewModel viewModel)
        {
            if (viewModel.DeviceId == 0)
            {
                ModelState.AddModelError("ScannerId", "Scanner is required");
                viewModel.Initialize(_printerRepository, _copierRepository);
                return View(viewModel);
            }

            var printQueueElement = new PrintQueueElement
            {
                DocumentId = viewModel.DocumentId,
                PrinterId = viewModel.DeviceId,
                Status = Enums.Status.Queued
            };
            _printQueueRepository.Save(printQueueElement);
            await _printerService.PrintAsync(printQueueElement.Id);
            return RedirectToAction("Index");
        }
    }
}