using EPostaGonderimApp.ConsumeAPI.Clients.Abstract;
using EPostaGonderimApp.ConsumeAPI.Models.EPostaViewModels;
using EPostaGonderimApp.ConsumeAPI.Models.KisiViewModels;
using EPostaGonderimApp.ConsumeAPI.Models.EPostaAdresViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using EPostaGonderimApp.ConsumeAPI.Models.FiltreViewModels;

namespace EPostaGonderimApp.ConsumeAPI.Controllers
{
    public class EPostaController : Controller
    {
        private readonly IEPostaClient _ePostaClient;
        private readonly IKisiClient _kisiClient;
        private readonly IEPostaAdresClient _ePostaAdresClient;

        public EPostaController(IEPostaClient ePostaClient,IKisiClient kisiClient, IEPostaAdresClient ePostaAdresClient)
        {
            _ePostaClient = ePostaClient;
            _kisiClient = kisiClient;
            _ePostaAdresClient = ePostaAdresClient;
        }
        public async Task<IActionResult> EPostaListesi()
        {
            List<EPostaListVM> ePostaList = new List<EPostaListVM>();

            var result = await _ePostaClient.EPostaList();

            if (result.IsSuccessStatusCode)
            {
                string data = result.Content.ReadAsStringAsync().Result;
                ePostaList = JsonConvert.DeserializeObject<List<EPostaListVM>>(data);

            }
            return View(ePostaList);
        }

        [HttpGet]
        public IActionResult KisiFiltrele()
        {
            ViewBag.Cinsiyet = new List<SelectListItem>()
            {
                new SelectListItem{ Text="Bir değer seçiniz.",Value=""},
                new SelectListItem{ Text="Kadın",Value="Kadın"},
                new SelectListItem{ Text="Erkek",Value="Erkek"}
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KisiFiltrele(KisiFilterVM model)
        {

            List<KisiListVM> kisiList = new List<KisiListVM>();

            HttpRequestMessage request = new HttpRequestMessage();

            var result = await _kisiClient.KisiListByFilter(request,model);

            if (result.IsSuccessStatusCode)
            {
                string data = result.Content.ReadAsStringAsync().Result; ;
                kisiList = JsonConvert.DeserializeObject<List<KisiListVM>>(data);
                TempData["KisiListesi"] = JsonConvert.SerializeObject(kisiList);

            }

            return RedirectToAction("KisiSec");
            
        }

        [HttpGet]
        public async Task<IActionResult> KisiSec()
        {
            List<KisiListVM> kisiList = new List<KisiListVM>();
            if (TempData["KisiListesi"] != null)
            {

                kisiList = JsonConvert.DeserializeObject<List<KisiListVM>>(TempData["KisiListesi"].ToString());
                return View(kisiList);
            }
            else
            {
                
                var result = await _kisiClient.KisiList();

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result; ;
                    kisiList = JsonConvert.DeserializeObject<List<KisiListVM>>(data);

                }

                return View(kisiList);
            }
            
        }

        
        public IActionResult KisiSeciminiIlet(List<KisiListVM> model)
        {

            EPostaDetailVM detayModel = new EPostaDetailVM();
            detayModel.Kisiler = new List<KisiListVM>();


            foreach (var item in model)
            {
                if (item.SecildiMi == true)
                {
                    KisiListVM dd = new KisiListVM();
                    dd.EPostaAdresi = item.EPostaAdresi;
                    dd.KisiID = item.KisiID;
                    detayModel.Kisiler.Add(dd);
                }
            }

            TempData["SecilenKisiler"] = JsonConvert.SerializeObject(detayModel.Kisiler);
            return RedirectToAction("EPostaEkle");
        }

        //[HttpGet]
        public async Task<IActionResult> EPostaEkle(List<KisiListVM> model)
        {
            var adresList= await EPostaAdresleri();
            ViewBag.EPostaAdresleri = adresList.ToList();

            model = JsonConvert.DeserializeObject<List<KisiListVM>>(TempData["SecilenKisiler"].ToString());

            EPostaDetailVM detayModel = new EPostaDetailVM();
            detayModel.Kisiler = model;

            return View(detayModel);
        }

        [HttpPost]
        public async Task<IActionResult> EPostaEkle(EPostaDetailVM model)
        {
            if (ModelState.IsValid)
            {
                HttpRequestMessage request = new HttpRequestMessage();
                var result = await _ePostaClient.EPostaDetail(request, model);
                if (result.IsSuccessStatusCode)
                {
                    TempData["Alert"] = "Kişi ekleme işlemi başarıyla gerçekleştirildi.";
                }
                else
                {
                    TempData["Alert"] = "Beklenmedik bir hata meydana geldi.Lütfen tekrar deneyiniz.";
                }
               
                return RedirectToAction("EPostaListesi");
            }
            else
            {
                ViewBag.Alert = "Beklenmedik bir hata meydana geldi.Lütfen tekrar deneyiniz.";
                return View(model);
            }


        }

        public async  Task<JsonResult> EPostaGoruntule(int id)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            var result = await _ePostaClient.Icerik(request,id);
            string data = result.Content.ReadAsStringAsync().Result;
            return Json(data);
        }

        private async Task<IEnumerable<SelectListItem>> EPostaAdresleri()
        {
            var itemList = new List<SelectListItem>();
            List<EPostaAdresListVM> ePostaAdresList = new List<EPostaAdresListVM>();

            var result = await _ePostaAdresClient.EPostaAdresList();

            if (result.IsSuccessStatusCode)
            {
                string data = result.Content.ReadAsStringAsync().Result;
                ePostaAdresList = JsonConvert.DeserializeObject<List<EPostaAdresListVM>>(data);
                return ePostaAdresList.Select(x => new SelectListItem
                {
                    Value = x.EPostaAdresID.ToString(),
                    Text = x.Adres
                }); ;

            }

            

            return itemList;
        }

       
    }
}
