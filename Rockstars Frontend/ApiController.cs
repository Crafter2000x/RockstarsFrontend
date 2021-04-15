﻿using System;
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
        public List<TalkModel> talks = new List<TalkModel>();
        public bool connection = false;

        public async Task ArtikelPaginaAPI()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Post");

                if (Res.IsSuccessStatusCode)
                {
                    connection = true;
                    var artikelResponse = Res.Content.ReadAsStringAsync().Result;
                    artikelen = JsonConvert.DeserializeObject<List<ArtikelModel>>(artikelResponse);
                }
            }
        }
        public async Task TalkAPI()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Post");

                if (Res.IsSuccessStatusCode)
                {
                    connection = true;
                    var talkResponse = Res.Content.ReadAsStringAsync().Result;
                    talks = JsonConvert.DeserializeObject<List<TalkModel>>(talkResponse);
                }
            }
        }

        public async Task AddToAPI(FormulierModel form)
        {
            using (var client = new HttpClient())
            {
              client.BaseAddress= new Uri(Baseurl);
              client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
              var json = System.Text.Json.JsonSerializer.Serialize(form);
                

              HttpResponseMessage Res = await client.PostAsJsonAsync("api/Appointment",json);
                if (Res.IsSuccessStatusCode)
                {
                    connection = true;
                }
                else
                {
                    throw new Exception(Res.ReasonPhrase);
                }


            }
        }
        public async Task AddToAPI(TalkModel talk)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var json = System.Text.Json.JsonSerializer.Serialize(talk);


                HttpResponseMessage Res = await client.PostAsJsonAsync("api/Appointment", json);
                if (Res.IsSuccessStatusCode)
                {
                    connection = true;
                }
                else
                {
                    throw new Exception(Res.ReasonPhrase);
                }


            }
        }
    }
}