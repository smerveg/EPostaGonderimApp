using EPostaGonderimApp.ConsumeAPI.Models.EPostaAdresViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Clients.Abstract
{
    public interface IEPostaAdresClient
    {
        Task<HttpResponseMessage> EPostaAdresList();
        Task<HttpResponseMessage> EPostaAdresDetail(HttpRequestMessage request, EPostaAdresDetailVM model);
    }
}
