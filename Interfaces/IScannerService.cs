namespace PrintManager.Interfaces
{
    public interface IScannerService
    {
        IQueryable<IScanner> GetAll();
    }
}