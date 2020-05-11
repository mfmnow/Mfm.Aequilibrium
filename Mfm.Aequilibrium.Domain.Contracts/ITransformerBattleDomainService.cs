using Mfm.Aequilibrium.Data.Entities;
using Mfm.Aequilibrium.Domain.Models;
using Mfm.Aequilibrium.Domain.Models.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfm.Aequilibrium.Domain.Contracts
{
    public interface ITransformerBattleDomainService
    {
        Task<TransformerBattleResultModel> GetTransformersBattleResult(List<int> transformersIds);
        Task<TransformerType> GetBattleWinner(TransformerBattleModel autobotsTransformer, TransformerBattleModel decepticonsTransformer);
        void MarkAsWinner(TransformerBattleModel autobotsTransformer, TransformerBattleModel decepticonsTransformer,
            TransformerType transformerType);
    }
}
