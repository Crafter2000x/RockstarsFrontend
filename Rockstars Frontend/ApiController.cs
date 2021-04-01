using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Rockstars_Frontend.Models;

namespace Rockstars_Frontend
{
    public class ApiController
    {
        string Baseurl = "https://localhost:6001/";
        public List<ArtikelModel> artikelen = new List<ArtikelModel>();
        public bool connection = false;

        public async Task ArtikelPaginaAPI()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Article");

                if (Res.IsSuccessStatusCode)
                {
                    connection = true;
                    var artikelResponse = Res.Content.ReadAsStringAsync().Result;
                    artikelen = JsonConvert.DeserializeObject<List<ArtikelModel>>(artikelResponse);
                }
            }
        }

        public void AddToAPI(FormulierModel form)
        {
            // KOMT LATER
        }
    }
}
