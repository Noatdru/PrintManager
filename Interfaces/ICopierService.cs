namespace PrintManager.Interfaces
{
    public interface ICopierService
    {
        IQueryable<ICopier> GetAll();
    }
}