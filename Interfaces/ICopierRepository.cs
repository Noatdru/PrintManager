using PrintManager.Models;

namespace PrintManager.Interfaces
{
    public interface ICopierRepository
    {
        IQueryable<Copier> GetAll();
        bool Save(Copier copier);
        void Delete(Copier copier);
        Copier GetById(int scannerId);
    }
}