using Mfm.Aequilibrium.Data.Entities;
using Mfm.Aequilibrium.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfm.Aequilibrium.Domain.Contracts
{
    public interface ITransformerBattleDomainService
    {
        Task<TransformerBattleResultModel> GetTransformersBattleResult(List<int> transformersIds);
        Task GetBattleWinner(TransformerEntity autobotsTransformer, TransformerEntity decepticonsTransformer,
            ref int autobotsWins, ref int decepticonsWins);
    }
}
