using Mfm.Aequilibrium.Domain.Services.UnitTests.MockProviders;
using Newtonsoft.Json;
using Xunit;

namespace Mfm.Aequilibrium.Domain.Services.UnitTests
{
    public class TransformerMapperDomainServiceUnitTests
    {
        [Fact]
        public void TransformerEntityToTransformerDisplayModel_Should_Return_Correct_Result()
        {
            var transformerMapperDomainService = new TransformerMapperDomainService();
            var result = transformerMapperDomainService.TransformerEntityToTransformerDisplayModel(TransformerMapperDomainServiceMockerProvider.MockedTransformerEntity);
            Assert.Equal(JsonConvert.SerializeObject(result), JsonConvert.SerializeObject(TransformerMapperDomainServiceMockerProvider.ExpectedTransformerDisplayModel));
        }        
    }
}