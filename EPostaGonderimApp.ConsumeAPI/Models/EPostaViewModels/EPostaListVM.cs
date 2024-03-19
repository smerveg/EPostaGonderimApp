using EPostaGonderimApp.ConsumeAPI.Models.EPostaAdresViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Models.EPostaViewModels
{
    public class EPostaListVM
    {
        [Display(Name = "ID")]
        public int EPostaID { get; set; }
        [Display(Name = "Konu")]
        public string Konu { get; set; }
        public int EPostaAdresID { get; set; }
        [Display(Name = "Gönderilen Adres")]
        public string Adres { get; set; }


    }
}
