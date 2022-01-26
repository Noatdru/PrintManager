using PrintManager.Models;

namespace PrintManager.Interfaces
{
    public interface IPrinterRepository
    {
        IQueryable<Printer> GetAll();
        bool Save(Printer printer);
        void Delete(Printer printer);
    }
}