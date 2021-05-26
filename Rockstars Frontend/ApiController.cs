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
        public List<Tribe> AllTribes = new List<Tribe>();
        public List<TalkModel> talks = new List<TalkModel>();
        public List<PodcastModel> podcasts = new List<PodcastModel>();
        public bool connection = false;

        public async Task PostOverzichtAPI(int PostType, int PageSize, int Page)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Post/type?type=" + PostType + "&pagesize=" + PageSize + "&page=" + Page + "");

                if (Res.IsSuccessStatusCode)
                {
                    switch (PostType)
                    {
                        case 0:
                            connection = true;
                            var artikelResponse = Res.Content.ReadAsStringAsync().Result;
                            artikelen = JsonConvert.DeserializeObject<List<ArtikelModel>>(artikelResponse);
                            break;

                        case 1:
                            connection = true;
                            var talkResponse = Res.Content.ReadAsStringAsync().Result;
                            talks = JsonConvert.DeserializeObject<List<TalkModel>>(talkResponse);
                            break;

                        case 2:
                            connection = true;
                            var podcastResponse = Res.Content.ReadAsStringAsync().Result;
                            podcasts = JsonConvert.DeserializeObject<List<PodcastModel>>(podcastResponse);
                            break;
                    }          
                }
            }
        }

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
        public async Task TribePaginaAPI()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Tribe");

                if (Res.IsSuccessStatusCode)
                {
                    connection = true;
                    var TribeResponse = Res.Content.ReadAsStringAsync().Result;
                    AllTribes = JsonConvert.DeserializeObject<List<Tribe>>(TribeResponse);
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
        public async Task PodcastAPI()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Post");

                if (Res.IsSuccessStatusCode)
                {
                    connection = true;
                    var podcastResponse = Res.Content.ReadAsStringAsync().Result;
                    podcasts = JsonConvert.DeserializeObject<List<PodcastModel>>(podcastResponse);
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
