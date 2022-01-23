using PrintManager.Models;

namespace PrintManager.Interfaces
{
    public interface IPrinter
    {
        Task PrintAsync(Document document);
    }
}
