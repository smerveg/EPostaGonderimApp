using EPostaGonderimApp.ConsumeAPI.Models.EPostaViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Clients.Abstract
{
    public interface IEPostaClient
    {
        Task<HttpResponseMessage> EPostaList();
        Task<HttpResponseMessage> EPostaDetail(HttpRequestMessage request, EPostaDetailVM model);
        Task<HttpResponseMessage> Icerik(HttpRequestMessage request, int id);
    }
}
