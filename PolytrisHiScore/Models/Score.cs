using RichTea.Common;

namespace PolytrisHiScore.Models
{
    public class Score
    {
        public string Name { get; set; }
        public int Lines { get; set; }
        public int Points { get; set; }
        public int Blocks { get; set; }

        public override string ToString()
        {

            return new ToStringBuilder<Score>(this)
                .Append(p => p.Name)
                .Append(p => p.Lines)
                .Append(p => p.Points)
                .Append(p => p.Blocks)
                .ToString();
        }
    }
}
