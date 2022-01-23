namespace PrintManager.Interfaces
{
    public interface IPrinterService
    {
        IQueryable<IPrinter> GetAll();
    }
}