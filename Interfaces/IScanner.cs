using PrintManager.Models;

namespace PrintManager.Interfaces
{
    public interface IScanner
    {
        Task<Document> ScanAsync();
    }
}
