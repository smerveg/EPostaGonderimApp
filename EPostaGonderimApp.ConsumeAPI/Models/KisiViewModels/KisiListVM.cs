using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Models.KisiViewModels
{
    public class KisiListVM
    {
        [Display(Name = "ID")]
        public int KisiID { get; set; }
        [Display(Name = "Ad")]
        public string Ad { get; set; }
        [Display(Name = "Soyad")]
        public string Soyad { get; set; }
        [Display(Name = "E-Posta Adresi")]
        public string EPostaAdresi { get; set; }
        public bool SecildiMi { get; set; }
    }
}
