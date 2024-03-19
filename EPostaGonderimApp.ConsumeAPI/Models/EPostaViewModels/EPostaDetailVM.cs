using EPostaGonderimApp.ConsumeAPI.Models.KisiViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Models.EPostaViewModels
{
    public class EPostaDetailVM
    {
        [Display(Name = "ID")]
        public int EPostaID { get; set; }
        [Display(Name = "Gönderim Tarihi")]
        public DateTime GonderimTarihi { get; set; }
        [Display(Name = "Konu")]
        public string Konu { get; set; }
        [Display(Name = "Gönderim Durumu")]
        public bool GonderimDurumu { get; set; }
        [Display(Name = "İçerik")]
        public string Icerik { get; set; }
        public int EPostaAdresID { get; set; }
        public List<KisiListVM> Kisiler { get; set; }
        public ICollection<int> KisiIdleri { get; set; }
    }
}
