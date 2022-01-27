using PrintManager.Models;

namespace PrintManager.Interfaces
{
    public interface IPrinterService
    {
        Task PrintAsync(int printQueueElementId);
    }
}