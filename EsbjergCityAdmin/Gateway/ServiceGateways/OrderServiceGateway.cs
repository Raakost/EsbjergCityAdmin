using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Gateway.Models;
using System.Web;

namespace Gateway.ServiceGateways
{
    public class OrderServiceGateway : IServiceGateway<Order>
    {
        private void ServiceGateway(HttpClient client)
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["API_Address"]);
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
        public Order Create(Order t)
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.PostAsJsonAsync("api/orders", t).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Order>().Result;
                }
                return null;
            }
        }

        public List<Order> GetAll()
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.GetAsync("api/orders").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<List<Order>>().Result;
                }
                return null;
            }
        }

        public Order Get(int id)
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.GetAsync($"api/orders/{id}").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Order>().Result;
                }
                return null;
            }
        }

        public Order Update(Order t)
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.PutAsJsonAsync($"api/orders/{t.Id}", t).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Order>().Result;
                }
                return null;
            }
        }

        public bool Delete(Order t)
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.DeleteAsync($"api/orders/{t.Id}").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<Order>().Result != null;
                }
                return false;
            }
        }
    }
}
