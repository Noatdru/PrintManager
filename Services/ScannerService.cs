using PrintManager.Interfaces;
using PrintManager.Models;

namespace PrintManager.Services
{
    public class ScannerService : IScannerService
    {
        private readonly IScannerRepository _scannerRepository;
        private readonly ICopierRepository _copierRepository;
        private readonly IDocumentRepository _documentRepository;

        public ScannerService(IScannerRepository scannerRepository, ICopierRepository copierRepository, IDocumentRepository documentRepository)
        {
            _scannerRepository = scannerRepository;
            _copierRepository = copierRepository;
            _documentRepository = documentRepository;
        }

        public async Task ScanAsync(int scannerId)
        {
            IScanner scanner = _scannerRepository.GetById(scannerId) ?? (IScanner)_copierRepository.GetById(scannerId);
            var document = await scanner.ScanAsync();
            _documentRepository.Save(document);
        }
    }
}