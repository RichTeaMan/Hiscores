using RichTea.Common;
using System;

namespace PolytrisHiScore.Models
{
    public class Score
    {
        public string Name { get; set; }
        public int Lines { get; set; }
        public int Points { get; set; }
        public int Blocks { get; set; }
        public DateTime PostedOn { get; set; }
        public string IpAddress { get; set; }

        public override string ToString()
        {

            return new ToStringBuilder<Score>(this)
                .Append(s => s.Name)
                .Append(s => s.Lines)
                .Append(s => s.Points)
                .Append(s => s.Blocks)
                .Append(s => s.PostedOn)
                .Append(s => s.IpAddress)
                .ToString();
        }
    }
}
