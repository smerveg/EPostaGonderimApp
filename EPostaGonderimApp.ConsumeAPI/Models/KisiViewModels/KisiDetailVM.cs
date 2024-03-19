using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPostaGonderimApp.ConsumeAPI.Models.KisiViewModels
{
    public class KisiDetailVM
    {
        //public int KisiID { get; set; }
        [Required(ErrorMessage ="Lütfen bir değer giriniz.")]
        [Display(Name ="Ad")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Lütfen bir değer giriniz.")]
        [Display(Name = "Soyad")]
        public string Soyad { get; set; }
        [Display(Name = "Cinsiyet")]
        public string Cinsiyet { get; set; }
        [Display(Name = "Doğum Tarihi")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? DogumTarihi { get; set; }
        [Required(ErrorMessage = "Lütfen bir değer giriniz.")]
        [EmailAddress(ErrorMessage ="Lütfen geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-Posta Adresi")]
        public string EPostaAdresi { get; set; }
        //[Phone(ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz.")]
        //[DataType(DataType.PhoneNumber)]
        [Display(Name = "Ev Telefonu")]
        public string EvTelefonu { get; set; }
        //[Phone(ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz.")]
        //[DataType(DataType.PhoneNumber)]
        [Display(Name = "Cep Telefonu")]
        public string CepTelefonu { get; set; }
        [Display(Name = "Unvan")]
        public string Unvan { get; set; }
        [Display(Name = "İş Yeri Adı")]
        public string IsYeriAdi { get; set; }
    }
}
