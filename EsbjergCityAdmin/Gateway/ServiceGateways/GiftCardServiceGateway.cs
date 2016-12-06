using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Gateway.Models;

namespace Gateway.ServiceGateways
{
    public class GiftCardServiceGateway: IServiceGateway<GiftCard>
    {
        private void ServiceGateway(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:6681/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public GiftCard Create(GiftCard t)
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.PostAsJsonAsync("api/giftcards", t).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<GiftCard>().Result;
                }
                return null;
            }
        }

        public List<GiftCard> GetAll()
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.GetAsync("api/giftcards").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<List<GiftCard>>().Result;
                }
                return null;
            }
        }

        public GiftCard Get(int id)
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.GetAsync($"api/giftcards/{id}").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<GiftCard>().Result;
                }
                return null;
            }
        }

        public GiftCard Update(GiftCard t)
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.PutAsJsonAsync($"api/giftcards/{t.Id}", t).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<GiftCard>().Result;
                }
                return null;
            }
        }

        public bool Delete(GiftCard t)
        {
            using (var client = new HttpClient())
            {
                ServiceGateway(client);
                HttpResponseMessage responseMessage = client.DeleteAsync($"api/giftcards/{t.Id}").Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<GiftCard>().Result != null;
                }
                return false;
            }
        }
    }
}
