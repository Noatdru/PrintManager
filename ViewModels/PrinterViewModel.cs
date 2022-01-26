using PrintManager.Models;

namespace PrintManager.ViewModels
{
    public class PrinterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        internal static PrinterViewModel FromPrinter(Printer printer)
        {
            return new PrinterViewModel
            {
                Id = printer.Id,
                Name = printer.Name,
                Location = printer.Location,
                Description = printer.Description
            };
        }

        internal Printer ToPrinter()
        {
            return new Printer
            {
                Id = Id,
                Name = Name,
                Location = Location,
                Description = Description
            };
        }
    }
}