using System.ComponentModel.DataAnnotations;
using PrintManager.Interfaces;
using PrintManager.Models;

namespace PrintManager.ViewModels
{
    public class PrintDocumentViewModel
    {
        [Display(Name = "Printer")]
        public int DeviceId { get; set; }
        public int DocumentId { get; set; }
        public List<Device> Devices { get; set; }

        public void Initialize(IPrinterRepository printerRepository, ICopierRepository copierRepository)
        {
            Devices = printerRepository.GetAll().ToList().Concat<Device>(copierRepository.GetAll().ToList()).ToList();
        }
    }
}