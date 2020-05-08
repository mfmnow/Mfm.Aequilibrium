using Mfm.Aequilibrium.Domain.Models.Enums;
using System.Collections.Generic;

namespace Mfm.Aequilibrium.Domain.Models
{
    public class TransformerBattleResultModel
    {
        public int NumberOfBattles { get; set; }
        public char Winner { get; set; }
        public List<TransformerDisplayModel> SurvivorsFromTheLosingTeam { get; set; }
    }
}
