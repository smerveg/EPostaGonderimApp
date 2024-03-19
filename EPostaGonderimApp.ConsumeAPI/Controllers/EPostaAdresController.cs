using EPostaGonderimApp.ConsumeAPI.Clients.Abstract;
using EPostaGonderimApp.ConsumeAPI.Models.EPostaAdresViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Controllers
{
    public class EPostaAdresController : Controller
    {
        private readonly IEPostaAdresClient _ePostaAdresClient;

        public EPostaAdresController(IEPostaAdresClient ePostaAdresClient)
        {
            _ePostaAdresClient = ePostaAdresClient;
        }
        public async Task<IActionResult> EPostaAdresListesi()
        {
            List<EPostaAdresListVM> EPostaAdresListe = new List<EPostaAdresListVM>();

            var result = await _ePostaAdresClient.EPostaAdresList();

            if (result.IsSuccessStatusCode)
            {
                string data = result.Content.ReadAsStringAsync().Result;
                EPostaAdresListe = JsonConvert.DeserializeObject<List<EPostaAdresListVM>>(data);

            }
            return View(EPostaAdresListe);
        }

        [HttpGet]
        public IActionResult EPostaAdresEkle()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EPostaAdresEkle(EPostaAdresDetailVM model)
        {
            if (ModelState.IsValid)
            {
                HttpRequestMessage request = new HttpRequestMessage();
                var result = await _ePostaAdresClient.EPostaAdresDetail(request, model);
                if (result.IsSuccessStatusCode)
                {
                    TempData["Alert"] = "E-Posta Adres ekleme işlemi başarıyla gerçekleştirildi.";
                }
                else
                {
                    TempData["Alert"] = "Beklenmedik bir hata meydana geldi.Lütfen tekrar deneyiniz.";
                }

             
                return RedirectToAction("EPostaAdresListesi");
            }
            else
            {
                TempData["Alert"] = "Beklenmedik bir hata meydana geldi.Lütfen tekrar deneyiniz.";
                return View(model);
            }


        }
    }
}
