using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LyricFinderPWA.Web.Models;
using LyricFinderPWA.Web.Services;

namespace LyricFinderPWA.Web.Controllers
{
    public class HomeController : Controller
    {
        ILyricSearch _lyricSearch;

        public HomeController(ILyricSearch lyricSearch)
        {
            _lyricSearch = lyricSearch;
        }
        public IActionResult Index()
        {
            var lyricModel = new lyricModel();
            return View(lyricModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string SongTitle, string BandName)
        {
            var lyricModel = new lyricModel();
            lyricModel.Title = SongTitle;
            lyricModel.BandName = BandName;

            lyricModel.Lyric = await _lyricSearch.RetrieveLyric(SongTitle, BandName);

            return View("Index", lyricModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
