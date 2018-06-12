using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PolytrisHiScore.Models;

namespace PolytrisHiScore.Controllers
{
    [Route("api/[controller]")]
    public class ScoreController : Controller
    {

        private static List<Score> Score = new List<Score>();

        // POST api/values
        [HttpPost]
        public Score Post([FromHeader(Name = "name")] string name, [FromHeader(Name = ("lines"))]string lines, [FromHeader(Name = ("points"))]string points, [FromHeader(Name = "blocks")]string blocks)
        {
            int linesInt;
            int pointsInt;
            int blocksInt;

            if (!int.TryParse(lines, out linesInt))
            {
                throw new ArgumentException("Lines is not an integer.");
            }

            if (!int.TryParse(points, out pointsInt))
            {
                throw new ArgumentException("Points is not an integer.");
            }

            if (!int.TryParse(blocks, out blocksInt))
            {
                throw new ArgumentException("Blocks is not an integer.");
            }

            var score = new Score()
            {
                Name = name,
                Lines = linesInt,
                Points = pointsInt,
                Blocks = blocksInt
            };

            System.IO.File.AppendAllLines(@"C:\Users\thoma\Desktop\scores.txt", new[] { score.ToString() });

            Score.Add(score);

            return score;
        }

        public Score[] Get()
        {
            return Score.OrderByDescending(s => s.Points).ToArray();
        }
    }
}
