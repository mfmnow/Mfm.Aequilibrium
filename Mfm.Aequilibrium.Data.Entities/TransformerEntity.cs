namespace Mfm.Aequilibrium.Data.Entities
{
    public class TransformerEntity : BaseEntity
    {
        public string Name { get; set; }
        public byte Type { get; set; }
        public byte Strength { get; set; }
        public byte Intelligence { get; set; }
        public byte Speed { get; set; }
        public byte Endurance { get; set; }
        public byte Rank { get; set; }
        public byte Courage { get; set; }
        public byte Firepower { get; set; }
        public byte Skill { get; set; }
        public byte OverallRating { get; set; }
    }
}
