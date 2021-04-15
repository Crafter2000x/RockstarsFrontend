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
    public class SpotifyApiController
    {
/*        string Baseurl = "https://api.spotify.com/v1/";
        public PodcastModel podcast;

        public async Task<List<PodcastEpisode>> GetSpotifyList()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "BQD8O_PMmPfB5NAHpx83YyAamV-oPBvrvJUpRVGaZg38uLXll9E0smVKH2LxAqhMZGJF3LBjw54BamIDSy28csUtnkDJyis0aRDrV-n6XHCFCjgrACmyyo047JEKH_uK4Q1GN48ghKIkj2Fg9apXfKcUkXrnlA");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("shows/5tBcwUHyeJShKtIUhHkD7L/episodes");

                if (Res.IsSuccessStatusCode)
                {
                    var artikelResponse = Res.Content.ReadAsStringAsync().Result;
                    podcast = JsonConvert.DeserializeObject<PodcastModel>(artikelResponse);
                    return podcast.podcasts;
                } else
                {
                    throw new Exception(Res.ReasonPhrase);
                }
            }
        }*/

    }
}
