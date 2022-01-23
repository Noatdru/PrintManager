using PrintManager.Interfaces;

namespace PrintManager.Models
{
    public class Copier : Device, ICopier
    {
        public Task PrintAsync(Document document)
        {
            throw new NotImplementedException();
        }

        public Task CopyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Document> ScanAsync()
        {
            throw new NotImplementedException();
        }

        public bool CanPrint => true;
        public bool CanScan => true;
        public bool CanCopy => true;
    }
}