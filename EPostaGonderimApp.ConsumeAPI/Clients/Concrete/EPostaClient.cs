using EPostaGonderimApp.ConsumeAPI.Clients.Abstract;
using EPostaGonderimApp.ConsumeAPI.Models.EPostaViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Clients.Concrete
{
    public class EPostaClient:IEPostaClient
    {
        public HttpClient Client { get; }
        public EPostaClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44312/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "EPostaClientClient");
            Client = client;
        }

        public async Task<HttpResponseMessage> EPostaDetail(HttpRequestMessage request, EPostaDetailVM model)
        {
            model.GonderimTarihi = DateTime.Now;
            model.GonderimDurumu = true;
            request.RequestUri = new Uri(Client.BaseAddress + "api/EPosta/postEPosta");
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            return await Client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> EPostaList()
        {
            return await Client.GetAsync("api/EPosta/getAll");
        }

        public async Task<HttpResponseMessage> Icerik(HttpRequestMessage request, int id)
        {
            request.RequestUri = new Uri(Client.BaseAddress +
                "api/Eposta/getIcerik?id=" + id);
            request.Method = HttpMethod.Get;
            request.Content = new StringContent(JsonConvert.SerializeObject(id), System.Text.Encoding.UTF8, "application/json");
            return await Client.SendAsync(request);
        }

    }
}
