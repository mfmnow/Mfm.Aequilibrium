using Mfm.Aequilibrium.Data.Entities;
using Mfm.Aequilibrium.Domain.Models;

namespace Mfm.Aequilibrium.Domain.Contracts
{
    public interface ITransformerMapperDomainService
    {
        TransformerDisplayModel TransformerEntityToTransformerDisplayModel(TransformerEntity transformerEntity);
    }
}
