using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeAPI
{
    public class ContactRequester
    {
        private string url = "https://localhost:44338/";

        private HttpClient _client;

        public ContactRequester()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
        }

        public IEnumerable<Contact> GetAll()
        {
            using(HttpResponseMessage message = _client.GetAsync("api/contact").Result)
            {
                if(!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);
            }
        }

        public Contact GetById(int id)
        {
            using (HttpResponseMessage message = _client.GetAsync("api/contact/"+id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Contact>(json);
            }
        }

        public void Post(ContactForm c)
        {
            string jsonBody = JsonConvert.SerializeObject(c);

            using(HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                using(HttpResponseMessage message = _client.PostAsync("api/contact", content).Result)
                {
                    if(!message.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException();
                    }

                    Console.WriteLine("Enregistrement ok");
                }
            }
        }
    }
}
