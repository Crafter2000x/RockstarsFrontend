using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using Rockstars_Frontend.Models;

namespace Rockstars_Frontend
{
    public class Telemetry
    {

        ApiController api = new ApiController();

        public async Task TelemetryReady(IPAddress ip, string browser, TelemetryType type, string postName = "NULL")
        {
            string hash = HashCode(ip, browser);

            int postID = 99999;

            if(postName != "NULL" && type != 0)
            {
                postID = await GetID(postName);
            }

            TelemetryViewModel tel = new TelemetryViewModel();
            tel.fingerprint = hash;
            tel.userAgent = browser;
            tel.type = type;
            if(type != 0)
            {
                tel.properties = new Dictionary<string, string>();
                tel.properties.Add("post", postID.ToString());
            }

            await api.TelemetryAdd(tel);
        }

        public string HashCode(IPAddress ip, string browser)
        {
            string ipstring = ip.ToString();

            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(ipstring + browser);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }

        public async Task<int> GetID(string title)
        {
            await api.ArtikelPaginaAPI();
            bool found = false;
            List<ArtikelModel> artikelen = api.artikelen;
            foreach(ArtikelModel artikel in artikelen)
            {
                if(artikel.Title == title && artikel.Status == 1)
                {
                    found = true;
                    return artikel.Id;
                }
            }
            if(found == false) 
            {
                return 99999;
            }
            return 99999;
        }



    }
}
