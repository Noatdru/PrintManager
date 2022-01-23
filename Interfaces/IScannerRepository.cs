namespace PrintManager.Interfaces
{
    public interface IScannerRepository
    {
        IQueryable<IScanner> GetAll();
    }
}