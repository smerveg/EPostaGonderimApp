
using EPostaGonderimApp.ConsumeAPI.Clients.Abstract;
using EPostaGonderimApp.ConsumeAPI.Models.FiltreViewModels;
using EPostaGonderimApp.ConsumeAPI.Models.KisiViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Clients.Concrete
{
    public class KisiClient:IKisiClient
    {
        public HttpClient Client { get;}
        public KisiClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44312/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "KisiClient");
            Client = client;
        }

        public async Task<HttpResponseMessage> KisiList()
        {
            return await  Client.GetAsync("api/Kisi/getAll");
            
        }

        public async Task<HttpResponseMessage> KisiDetail(HttpRequestMessage request, KisiDetailVM model)
        {
            request.RequestUri = new Uri(Client.BaseAddress + "api/Kisi/postKisi");
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            return await Client.SendAsync(request);
        }

        public async Task<HttpResponseMessage> KisiListByFilter(HttpRequestMessage request, KisiFilterVM model)
        {
            request.RequestUri = new Uri(Client.BaseAddress + 
                "api/Kisi/getAllByFilter?ad="+model.Ad+"&soyad="+model.Soyad + "&cinsiyet=" + model.Cinsiyet + "&unvan=" + model.Unvan + "&isYeriAdi=" + model.IsYeriAdi );
            request.Method = HttpMethod.Get;
            request.Content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            return await Client.SendAsync(request);
        }
    }
}
