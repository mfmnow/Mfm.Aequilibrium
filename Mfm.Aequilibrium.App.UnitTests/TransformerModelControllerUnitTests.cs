using Mfm.Aequilibrium.App.Controllers;
using Mfm.Aequilibrium.Domain.Contracts;
using Mfm.Aequilibrium.Domain.Models.Exceptions;
using Mfm.Aequilibrium.App.UnitTests.MockProviders;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;
using Mfm.Aequilibrium.Domain.Models;

namespace Mfm.Aequilibrium.App.UnitTests
{
    public class TransformerModelControllerUnitTests
    {
        private readonly Mock<ITransformerDomainService> _mockedITransformerDomainService;
        private readonly Mock<ILogger<TransformerModelController>> _mockedLogger;
        private readonly Mock<TransformerModelController> _mockedTransformerModelController;

        public TransformerModelControllerUnitTests()
        {
            (_mockedITransformerDomainService, _mockedLogger, _mockedTransformerModelController) =
                TransformerModelControllerMockerProvider.GetMocks();
        }

        [Fact]
        public async Task CreateTransformer_Should_Follow_LogicalFlow_On_Valid_Model()
        {
            await _mockedTransformerModelController.Object.CreateTransformer(It.IsAny<TransformerModel>());

            _mockedITransformerDomainService.Verify(t => t.CreateTransformer(It.IsAny<TransformerModel>()), Times.Once);
        }

        [Fact]
        public async Task UpdateTransformer_Should_Follow_LogicalFlow_On_Valid_Model()
        {
            await _mockedTransformerModelController.Object.UpdateTransformer(It.IsAny<TransformerUpdateModel>());

            _mockedITransformerDomainService.Verify(t => t.UpdateTransformer(It.IsAny<TransformerUpdateModel>()), Times.Once);
        }

        [Fact]
        public async Task DeleteTransformer_Should_Follow_LogicalFlow_On_Valid_Model()
        {
            await _mockedTransformerModelController.Object.DeleteTransformer(It.IsAny<TransformerDeleteModel>());

            _mockedITransformerDomainService.Verify(t => t.DeleteTransformer(It.IsAny<TransformerDeleteModel>()), Times.Once);
        }

        [Fact]
        public async Task GetTransformers_Should_Follow_LogicalFlow_On_Valid_Model()
        {
            await _mockedTransformerModelController.Object.GetTransformers();

            _mockedITransformerDomainService.Verify(t => t.GetTransformers(), Times.Once);
        }
    }
}