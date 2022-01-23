using PrintManager.Interfaces;

namespace PrintManager.Models
{
    public class Scanner : Device, IScanner
    {

        public bool CanScan => true;

        public Task<Document> ScanAsync()
        {
            throw new NotImplementedException();
        }
    }
}