using System.ComponentModel.DataAnnotations;
using PrintManager.Interfaces;
using PrintManager.Models;

namespace PrintManager.ViewModels
{
    public class ScanDocumentViewModel
    {
        [Display(Name = "Scanner")]
        public int ScannerId { get; set; }
        public List<Device> Scanners { get; set; }
        internal void Initialize(IScannerRepository scannerRepository, ICopierRepository copierRepository)
        {
            Scanners = scannerRepository.GetAll().ToList().Concat<Device>(copierRepository.GetAll().ToList()).ToList();
        }
    }
}