using EPostaGonderimApp.ConsumeAPI.Clients.Abstract;
using EPostaGonderimApp.ConsumeAPI.Models.KisiViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Controllers
{
    public class KisiController : Controller
    {
        private readonly IKisiClient _kisiClient;

        public KisiController(IKisiClient kisiClient)
        {
            _kisiClient = kisiClient;
        }
        public async Task<IActionResult> KisiListesi()
        {
            List<KisiListVM> kisiListe = new List<KisiListVM>();

            var result = await _kisiClient.KisiList();

            if (result.IsSuccessStatusCode)
            {
                string data = result.Content.ReadAsStringAsync().Result; ;
                kisiListe = JsonConvert.DeserializeObject<List<KisiListVM>>(data);
                
            }
            return View(kisiListe);
        }

        [HttpGet]
        public IActionResult KisiEkle()
        {
            ViewBag.Cinsiyet = new List<SelectListItem>()
            {
                new SelectListItem{ Text="Kadın",Value="Kadın"},
                new SelectListItem{ Text="Erkek",Value="Erkek"}
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KisiEkle(KisiDetailVM model)
        {
            if (ModelState.IsValid)
            {
                HttpRequestMessage request = new HttpRequestMessage();
                var result = await _kisiClient.KisiDetail(request, model);
                if (result.IsSuccessStatusCode)
                {
                    TempData["Alert"] = "Kişi ekleme işlemi başarıyla gerçekleştirildi.";
                }
                else
                {
                    TempData["Alert"] = "Beklenmedik bir hata meydana geldi.Lütfen tekrar deneyiniz.";
                }
                
                return RedirectToAction("KisiListesi");
            }
            else
            {
                TempData["Alert"] = "Beklenmedik bir hata meydana geldi.Lütfen tekrar deneyiniz.";
                return View(model);
            }
            
            
        }
    }
}
