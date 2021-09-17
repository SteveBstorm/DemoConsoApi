using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace ConsumeAPI
{
    class UserRequester
    {
        private string url = "https://localhost:44327/api/";

        private HttpClient _client;

        public UserRequester()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
        }

        public User Login(string email, string password)
        {
            string jsonBody = JsonConvert.SerializeObject(new { email = email, password = password });
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            string jsonResponse;
            using (HttpResponseMessage response = _client.PostAsync("user/login", content).Result)
            {
                response.EnsureSuccessStatusCode();
                jsonResponse = response.Content.ReadAsStringAsync().Result;

            }

            return JsonConvert.DeserializeObject<User>(jsonResponse);
        }

        public IEnumerable<User> GetAll(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using (HttpResponseMessage message = _client.GetAsync("user").Result)
            {

                if(message.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<User>>(json);
                }
                else
                {
                    throw new Exception(message.StatusCode.ToString());
                }
            }
        }

    }
}
