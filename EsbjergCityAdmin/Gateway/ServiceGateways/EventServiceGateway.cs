using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Gateway.Models;
using System.Web;

namespace Gateway.ServiceGateways
{
    public class EventServiceGateway : IServiceGateway<Event>
    {
        private void ServiceGateway(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:6681/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (HttpContext.Current.Session["token"] != null)
            {
                string token = HttpContext.Current.Session["token"].ToString();
                if (client.DefaultRequestHeaders.Authorization == null)
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                }
            }
        }

        public Event Create(Event t)
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.PostAsJsonAsync("api/events", t).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Event>().Result;
                }
                return null;
            }
        }

        public List<Event> GetAll()
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.GetAsync("api/events").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<List<Event>>().Result;
                }
                return null;
            }
        }

        public Event Get(int id)
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.GetAsync($"api/events/{id}").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Event>().Result;
                }
                return null;
            }
        }

        public Event Update(Event t)
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.PutAsJsonAsync($"api/events/{t.Id}", t).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Event>().Result;
                }
                return null;
            }
        }

        public bool Delete(Event t)
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.DeleteAsync($"api/events/{t.Id}").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Event>().Result != null;
                }
                return false;
            }
        }
    }
}
