using System;
using ChallengeSGB.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ChallengeSGB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChallengeContext _context;

        public HomeController(ChallengeContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}