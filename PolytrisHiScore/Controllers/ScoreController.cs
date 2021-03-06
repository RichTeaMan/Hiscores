﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PolytrisHiScore.Models;

namespace PolytrisHiScore.Controllers
{
    [Route("api/[controller]")]
    public class ScoreController : Controller
    {

        public static string JsonPath = Constants.ScoreJsonFilePath;

        public static ConcurrentBag<Score> Scores { get; private set; } = new ConcurrentBag<Score>();

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
                Name = name.Substring(0, Math.Min(name.Length, 20)),
                Lines = linesInt,
                Points = pointsInt,
                Blocks = blocksInt,
                PostedOn = DateTime.Now,
                IpAddress = this.Request.HttpContext.Connection.RemoteIpAddress.ToString()
            };

            Scores.Add(score);

            var scoreJson = JsonConvert.SerializeObject(Scores, Formatting.Indented);
            System.IO.File.WriteAllText(JsonPath, scoreJson);

            return score;
        }

        [HttpGet]
        public Score[] Get()
        {
            return Scores.OrderByDescending(s => s.Points).ToArray();
        }

        [HttpGet("uniqueName")]
        public Score[] ByUniqueName()
        {

            return Scores.GroupBy(s => s.Name)
                .Select(g => g.OrderByDescending(s => s.Points).First())
                .OrderByDescending(s => s.Points)
                .ToArray();

        }
    }
}
