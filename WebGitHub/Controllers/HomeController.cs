using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WebGitHub.Models;

namespace WebGitHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Test()
        {
            var model = new MyModel();
            var patern = @"~`(.+?)`~";
            var rx = new Regex(patern);
            string st = "I want to see ~`9`~ in my notes ~`19`~ ~`999`~ ~`0`~";
             
            MatchCollection matches = rx.Matches(st);
            foreach (Match match in matches)
            {
                model.group0 += match.Groups[0].Value;
                model.group1 += match.Groups[1].Value;
                model.matches += 1;
                var t = st.Contains(match.Groups[0].Value);
                st = st.Replace(match.Groups[0].Value.ToString(), model.matches.ToString());
            }
            model.text = st;
            return View(model);
        }
    }
}