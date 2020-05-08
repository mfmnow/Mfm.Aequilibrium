using Mfm.Aequilibrium.App.Controllers;
using Mfm.Aequilibrium.Domain.Contracts;
using Mfm.Aequilibrium.Domain.Models;
using Microsoft.Extensions.Logging;
using Moq;

namespace Mfm.Aequilibrium.App.UnitTests.MockProviders
{
    internal class TransformerModelControllerMockerProvider
    {
        public static (Mock<ITransformerDomainService>, Mock<ILogger<TransformerModelController>>,
            Mock<TransformerModelController>) GetMocks() {
            var mockedITransformerDomainService = new Mock<ITransformerDomainService>();
            var mockedLogger = new Mock<ILogger<TransformerModelController>>();
            var mockedTransformerModelController = new Mock<TransformerModelController>(mockedITransformerDomainService.Object,
                mockedLogger.Object)
            { CallBase = true };
            return (mockedITransformerDomainService, mockedLogger, mockedTransformerModelController);
        }
    }
}
