using EPostaGonderimApp.ConsumeAPI.Models.FiltreViewModels;
using EPostaGonderimApp.ConsumeAPI.Models.KisiViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Clients.Abstract
{
    public interface IKisiClient
    {
        Task<HttpResponseMessage> KisiList();
        Task<HttpResponseMessage> KisiListByFilter(HttpRequestMessage request,KisiFilterVM model);
        Task<HttpResponseMessage> KisiDetail(HttpRequestMessage request,KisiDetailVM model);
    }
}
