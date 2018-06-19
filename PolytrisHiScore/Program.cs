using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PolytrisHiScore.Models;

namespace PolytrisHiScore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                Controllers.ScoreController.JsonPath = args[1];
            }
            Console.WriteLine($"Using JSON from '{Controllers.ScoreController.JsonPath}'.");

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            if (File.Exists(Constants.ScoreJsonFilePath))
            {
                var scoreJson = File.ReadAllText(Constants.ScoreJsonFilePath);
                JsonConvert.DeserializeObject<List<Score>>(scoreJson).ForEach(s => Controllers.ScoreController.Scores.Add(s));
            }

            return WebHost.CreateDefaultBuilder(args)
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();
        }
    }
}
