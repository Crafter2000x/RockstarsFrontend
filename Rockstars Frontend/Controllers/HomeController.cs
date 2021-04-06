using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rockstars_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Rockstars_Frontend.Controllers
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

        public async Task<IActionResult> ArtikelPagina()
        {
            List<ArtikelModel> artikelen = new List<ArtikelModel>();
            ApiController api = new ApiController();
            await api.ArtikelPaginaAPI();
            artikelen = api.artikelen;
            return View(artikelen);
        }

        public IActionResult Artikel(string? title)
        {
            if (title == null)
            {
                return RedirectToAction("ArtikelPagina");
            }
            ViewData["ID"] = title;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
