using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintManager.Interfaces;

namespace PrintManager.Controllers
{
    [Authorize]
    public class PrinterController : Controller
    {
        private readonly IPrinterRepository _printerRepository;

        public PrinterController(IPrinterRepository printerRepository)
        {
            _printerRepository = printerRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var printers = _printerRepository.GetAll().ToList();
            return View();
        }
    }
}