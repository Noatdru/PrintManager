using System;
using PrintManager.Enums;
using PrintManager.Models;
using PrintManager.ViewModels;
using Xunit;

namespace PrintManager
{
	public class PrintQueueElementViewModelTest
	{

        [Fact]
        public void FromPrintQueueElement_NullParameter_ThrowsArgumentNullException()
        {
            const string expectedParameterName = "printQueueElement";
            var ex = Assert.Throws<ArgumentNullException>(() => PrintQueueElementViewModel.FromPrintQueueElement(null));
            Assert.Equal(expectedParameterName, ex.ParamName);
            
        }
        [Fact]
        public void FromPrintQueueElement_MapsCorrectly()
        {
            const int id = 3;
            const int documentId = 33;
            const int printerId = 11;
            const Status status = Status.Completed;

            var expectedResult = new PrintQueueElementViewModel
            {
                Id = id,
                DocumentId = documentId,
                Status = status,
                PrinterId = printerId
            };
            var mapperInput = new PrintQueueElement
            {
                Id = id,
                DocumentId = documentId,
                Status = status,
                PrinterId = printerId
            };

            var mapResult =  PrintQueueElementViewModel.FromPrintQueueElement(mapperInput);
            Assert.Equal(expectedResult.Id, mapResult.Id);
            Assert.Equal(expectedResult.DocumentId, mapResult.DocumentId);
            Assert.Equal(expectedResult.Status, mapResult.Status);
            Assert.Equal(expectedResult.PrinterId, mapResult.PrinterId);

        }
    }
}

