using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintManager.Enums;
using PrintManager.Interfaces;
using PrintManager.Models;
using PrintManager.ViewModels;

namespace PrintManager.Controllers
{
    [Authorize]
    public class PrintQueueController : Controller
    {
        private readonly IPrintQueueRepository _printQueueRepository;
        private readonly IPrinterRepository _printerRepository;
        private readonly ICopierRepository _copierRepository;
        private readonly IPrinterService _printerService;

        public PrintQueueController(IPrintQueueRepository printQueueRepository, IPrinterRepository printerRepository, ICopierRepository copierRepository, IPrinterService printerService)
        {
            _printQueueRepository = printQueueRepository;
            _printerRepository = printerRepository;
            _copierRepository = copierRepository;
            _printerService = printerService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var viewModel = _printQueueRepository.GetAll().Select(PrintQueueElementViewModel.FromPrintQueueElement).ToList();
            return View(viewModel);
        }
        public IActionResult Cancel(int id)
        {
            _printQueueRepository.ChangeStatus(id, Status.Canceled);
            return RedirectToAction("Index");
        }

    }
}