﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rockstars_Frontend.Models;
using System.Text.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Rockstars_Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        ApiController api = new ApiController();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string SearchTerm)
        {
            ViewData["KeyWord"] = SearchTerm;
            return View();
        }


        public async Task<IActionResult> ArtikelPagina()
        {
            ApiController api = new ApiController();
            ArtikelenViewModel artikelen = new ArtikelenViewModel();

            await api.ArtikelPaginaAPI();

            artikelen.artikelen = api.artikelen;
            return View(artikelen);
        }

        [HttpPost]
        public async Task<IActionResult> GetArtikelen(int LastId) 
        {
            ApiController api = new ApiController();
            await api.ArtikelPaginaAPI();
            List<ArtikelModel> ValidArtikelen = new List<ArtikelModel>();

            foreach (var item in api.artikelen)
            {
                //Switch status to 1 in production 
                if (item.Status == 0 && item.Type == 0)
                {
                    if (ValidArtikelen.Count ==6)
                    {
                        break;
                    }

                    if (item.Id > LastId)
                    {
                        ValidArtikelen.Add(item);
                    }
                }
            }
            var json = JsonConvert.SerializeObject(ValidArtikelen);

            return Content(json, "application/json");
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        public IActionResult Artikel(string? title)
        {
            if (title == null)
            {
                return RedirectToAction("TribeOverzicht");
            }
            ViewData["ID"] = title;
            return View();
        }
        public IActionResult OnDemand(string Tribe)
        {
            if (Tribe == null)
            {
                ViewData["TRIBE"] = "allen";
            }
            else
            {
                ViewData["TRIBE"] = Tribe;
            }

            return View();
        }


        public IActionResult Podcast(string? title)
        {
            if (title == null)
            {
                return RedirectToAction("Podcasts");
            }
            ViewData["ID"] = title;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OnDemand(FormulierEnAanvraagModel model)
        {
            if (model.form.preferredDateTime < DateTime.Now)
            {
                ModelState.AddModelError("model","Vul een geldige datum in.");
                return View();
            }
                if (ModelState.IsValid)
                {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("RockstarsITFrontEnd@gmail.com");
                    mail.To.Add(model.form.contactEmail);
                    mail.Subject = "Bevestiging";
                    mail.Body = "<h1>Hierbij krijgt u de bevestiging van uw talkaanvraag.</h1><br/>" +
                    "voorkeursdag:  " + model.form.preferredDateTime.ToString("dd-MM-yyyy") +
                    "<br/>bedrijfsnaam:  " + model.form.companyName +
                    "<br/>aantal mensen aanwezig:  " + model.form.amountOfPeople +
                    "<br/>tribe:  " + model.form.tribe.Title +
                    "<br/>opmerking:  " + model.form.comment +
                    "<br/>nummer:  " + model.form.phoneNumber;

                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("RockstarsITFrontEnd@gmail.com", "DitIsOnzeMail1234");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                return View();
                }
            
            //await api.AddToAPI(model.form);
            return View("OnDemand");
        }
        [HttpPost]
        public async Task<IActionResult> Aanvragen(FormulierEnAanvraagModel model)
        {
            if (ModelState.IsValid)
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("RockstarsITFrontEnd@gmail.com");
                    mail.To.Add(model.form.contactEmail);
                    mail.Subject = "Aangevraagde Talk";
                    //deze link moet uiteindelijk uit de api gehaald worden op basis van welke webinar je aanklikt.
                    mail.Body = "Link naar youtube:  https://www.youtube.com/watch?v=dQw4w9WgXcQ";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("RockstarsITFrontEnd@gmail.com", "DitIsOnzeMail1234");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                //await api.AddToAPI(model.talk);
                return RedirectToAction("OnDemand");
            }
                return View();
           
            
        }
        [HttpPost]
        public async Task<IActionResult> vragen(FormulierEnAanvraagModel model)
        {
            if (ModelState.IsValid)
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("RockstarsITFrontEnd@gmail.com");
                    mail.To.Add(model.form.contactEmail);
                    mail.Subject = "Aangevraagde Talk";
                    //deze link moet uiteindelijk uit de api gehaald worden op basis van welke webinar je aanklikt.
                    mail.Body = "Link naar youtube:  https://www.youtube.com/watch?v=dQw4w9WgXcQ";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("RockstarsITFrontEnd@gmail.com", "DitIsOnzeMail1234");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                //await api.AddToAPI(model.talk);
                return View(OnDemand("Tribe"));
            }
            return View();


        }

        public IActionResult TribeOverzicht()
        {
            return View();
        }
        public IActionResult TribePagina(string? title)
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
