using PrintManager.Models;

namespace PrintManager.Interfaces
{
    public interface IScannerRepository
    {
        IQueryable<Scanner> GetAll();
        bool Save(Scanner scanner);
        void Delete(Scanner scanner);
        Scanner GetById(int scannerId);
    }
}