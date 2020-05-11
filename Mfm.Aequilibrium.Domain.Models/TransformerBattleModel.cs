using Mfm.Aequilibrium.Domain.Models.Enums;

namespace Mfm.Aequilibrium.Domain.Models
{
    public class TransformerBattleModel
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public byte Strength { get; set; }
        public byte Courage { get; set; }
        public byte Skill { get; set; }
        public byte Rank { get; set; }
        public byte OverallRating { set; get; }
        public TransformerBattleStatus TransformerBattleStatus { get; set; }
        public TransformerType TransformerType { get; set; }
    }
}
