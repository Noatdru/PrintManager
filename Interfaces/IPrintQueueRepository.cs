using PrintManager.Enums;
using PrintManager.Models;

namespace PrintManager.Interfaces
{
    public interface IPrintQueueRepository
    {
        IQueryable<PrintQueueElement> GetAll();
        bool Save(PrintQueueElement printQueueElement);
        void ChangeStatus(int PrintQueueElementId, Status status);
        PrintQueueElement GetById(int printQueueElementId);
    }
}