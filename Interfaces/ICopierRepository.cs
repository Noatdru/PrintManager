namespace PrintManager.Interfaces
{
    public interface ICopierRepository
    {
        IQueryable<ICopier> GetAll();
    }
}