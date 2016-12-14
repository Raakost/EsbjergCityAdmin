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
    public class OrderServiceGateway : IServiceGateway<Order>
    {
        private HttpClient client;
        public OrderServiceGateway()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:6681/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Order Create(Order t)
        {
            HttpResponseMessage responseMessage = client.PostAsJsonAsync("api/orders", t).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return responseMessage.Content.ReadAsAsync<Order>().Result;
            }
            return null;
        }

        public List<Order> GetAll()
        {
            AddAuthorizationHeader();
            HttpResponseMessage responseMessage = client.GetAsync("api/orders").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return responseMessage.Content.ReadAsAsync<List<Order>>().Result;
            }
            return null;
        }

        public Order Get(int id)
        {
            HttpResponseMessage responseMessage = client.GetAsync($"api/orders/{id}").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return responseMessage.Content.ReadAsAsync<Order>().Result;
            }
            return null;
        }

        public Order Update(Order t)
        {
            HttpResponseMessage responseMessage = client.PutAsJsonAsync($"api/orders/{t.Id}", t).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return responseMessage.Content.ReadAsAsync<Order>().Result;
            }
            return null;
        }

        public bool Delete(Order t)
        {
            HttpResponseMessage responseMessage = client.DeleteAsync($"api/orders/{t.Id}").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return responseMessage.Content.ReadAsAsync<Order>().Result != null;
            }
            return false;
        }
        private void AddAuthorizationHeader()
        {
            if (HttpContext.Current.Session["token"] != null)
            {
                string token = HttpContext.Current.Session["token"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }
        }
    }
}
