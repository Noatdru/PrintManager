using PrintManager.Models;

namespace PrintManager.ViewModels
{
    public class ScannerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        internal static ScannerViewModel FromScanner(Scanner scanner)
        {
            return new ScannerViewModel
            {
                Id = scanner.Id,
                Name = scanner.Name,
                Location = scanner.Location,
                Description = scanner.Description
            };
        }

        internal Scanner ToScanner()
        {
            return new Scanner
            {
                Id = Id,
                Name = Name,
                Location = Location,
                Description = Description
            };
        }

    }
}