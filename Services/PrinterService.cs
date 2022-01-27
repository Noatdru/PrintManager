using PrintManager.Enums;
using PrintManager.Interfaces;

namespace PrintManager.Services
{
    public class PrinterService : IPrinterService
    {
        private readonly IPrinterRepository _printerRepository;
        private readonly ICopierRepository _copierRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IPrintQueueRepository _printQueueRepository;

        public PrinterService(IPrinterRepository printerRepository, ICopierRepository copierRepository, IDocumentRepository documentRepository, IPrintQueueRepository printQueueRepository)
        {
            _printerRepository = printerRepository;
            _copierRepository = copierRepository;
            _documentRepository = documentRepository;
            _printQueueRepository = printQueueRepository;
        }

        public async Task PrintAsync(int printQueueElementId)
        {
            var printQueueElement = _printQueueRepository.GetById(printQueueElementId);
            int printerId = printQueueElement.PrinterId;
            _printQueueRepository.ChangeStatus(printQueueElement.Id, Status.InProgress);
            IPrinter printer = _printerRepository.GetById(printerId) ?? (IPrinter)_copierRepository.GetById(printerId);
            await printer.PrintAsync(printQueueElement.Document);
            _printQueueRepository.ChangeStatus(printQueueElement.Id, Status.Completed);
        }
    }
}