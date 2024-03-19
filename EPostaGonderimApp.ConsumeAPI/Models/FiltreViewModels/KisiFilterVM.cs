using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Models.FiltreViewModels
{
    public class KisiFilterVM
    {
        [Display(Name = "Ad")]
        public string Ad { get; set; }
        [Display(Name = "Soyad")]
        public string Soyad { get; set; }
        [Display(Name = "Cinsiyet")]
        public string Cinsiyet { get; set; }
        [Display(Name = "Unvan")]
        public string Unvan { get; set; }
        [Display(Name = "İş Yeri Adı")]
        public string IsYeriAdi { get; set; }

    }
}
