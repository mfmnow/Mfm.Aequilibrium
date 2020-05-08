using Mfm.Aequilibrium.Domain.Models.Enums;

namespace Mfm.Aequilibrium.Domain.Models
{
    public class TransformerModel
    {
        public string Name { get; set; }
        public TransformerType TypeEnum { get; set; }
        public char Type { get; set; }
        public byte Strength { get; set; }
        public byte Intelligence { get; set; }
        public byte Speed { get; set; }
        public byte Endurance { get; set; }
        public byte Rank { get; set; }
        public byte Courage { get; set; }
        public byte Firepower { get; set; }
        public byte Skill { get; set; }
    }
}
