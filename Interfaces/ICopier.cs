namespace PrintManager.Interfaces
{
    public interface ICopier : IPrinter, IScanner
    {
        Task CopyAsync();
    }
}