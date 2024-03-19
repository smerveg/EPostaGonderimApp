using EPostaGonderimApp.ConsumeAPI.Clients.Abstract;
using EPostaGonderimApp.ConsumeAPI.Models.EPostaAdresViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Clients.Concrete
{
    public class EPostaAdresClient : IEPostaAdresClient
    {
        public HttpClient Client { get; }
        public EPostaAdresClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44312/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "EPostaAdresClient");
            Client = client;
        }
        public async Task<HttpResponseMessage> EPostaAdresDetail(HttpRequestMessage request, EPostaAdresDetailVM model)
        {
            request.RequestUri = new Uri(Client.BaseAddress + "api/EPostaAdres/postAdres");
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            return await Client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> EPostaAdresList()
        {
            return await Client.GetAsync("api/EPostaAdres/getAll");
        }
    }
}
