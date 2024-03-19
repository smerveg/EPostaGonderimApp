using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Models.EPostaAdresViewModels
{
    public class EPostaAdresDetailVM
    {
        public int EPostaAdresID { get; set; }
        [Required(ErrorMessage = "Lütfen bir değer giriniz.")]
        [Display(Name = "Adres")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen bir değer giriniz.")]
        [Display(Name = "Mail Sunucu Adres")]
        public string MailSunucuAdres { get; set; }
        [Required(ErrorMessage = "Lütfen bir değer giriniz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAd { get; set; }
        [Required(ErrorMessage = "Lütfen bir değer giriniz.")]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }
        [Required(ErrorMessage = "Lütfen bir değer giriniz.")]
        [Display(Name = "Port")]
        public string Port { get; set; }
    }
}
