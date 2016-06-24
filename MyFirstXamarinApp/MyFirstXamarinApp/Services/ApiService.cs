using MyFirstXamarinApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstXamarinApp.Services
{
    public class ApiService
    {
        public async Task<List<OnlineNote>> GetAllNotes()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://xamarinnotesapp.azurewebsites.net/tables/Note";
                client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
                var result = await client.GetAsync(url);

                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<OnlineNote>>(data);
                }
                else
                {
                    return new List<OnlineNote>();
                }
            }
        }

        public async Task<OnlineNote> AddNote(OnlineNote note)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://xamarinnotesapp.azurewebsites.net/tables/Note";
                client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");

                string content = JsonConvert.SerializeObject(note);
                StringContent body = new StringContent(content, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, body);

                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<OnlineNote>(data);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
