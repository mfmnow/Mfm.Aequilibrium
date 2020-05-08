using Mfm.Aequilibrium.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfm.Aequilibrium.Domain.Contracts
{
    public interface ITransformerDomainService
    {
        Task CreateTransformer(TransformerModel transformerModel);
        Task UpdateTransformer(TransformerUpdateModel transformerModel);
        Task DeleteTransformer(TransformerDeleteModel transformerDeleteModel);
        Task<List<TransformerDisplayModel>> GetTransformers();
    }
}
