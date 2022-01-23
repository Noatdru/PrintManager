namespace PrintManager.Interfaces
{
    public interface IPrinterRepository
    {
        IQueryable<IPrinter> GetAll();
    }
}