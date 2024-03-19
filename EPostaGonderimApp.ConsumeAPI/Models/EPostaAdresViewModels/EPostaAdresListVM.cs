using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Models.EPostaAdresViewModels
{
    public class EPostaAdresListVM
    {
        [Display(Name = "ID")]
        public int EPostaAdresID { get; set; }
        [Display(Name = "Adres")]
        public string Adres { get; set; }
        [Display(Name = "Mail Sunucu Adres")]
        public string MailSunucuAdres { get; set; }
    }
}
