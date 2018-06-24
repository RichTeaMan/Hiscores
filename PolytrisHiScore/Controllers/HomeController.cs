using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PolytrisHiScore.Models;

namespace PolytrisHiScore.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {

        public string Get()
        {
            return "hello world v1";
        }
    }
}
