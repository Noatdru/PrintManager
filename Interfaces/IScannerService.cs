namespace PrintManager.Interfaces
{
    public interface IScannerService
    {
        public Task ScanAsync(int scannerId);
    }
}