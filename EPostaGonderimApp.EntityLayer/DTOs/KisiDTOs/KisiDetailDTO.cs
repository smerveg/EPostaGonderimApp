using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.EntityLayer.DTOs.KisiDTOs
{
    public class KisiDetailDTO
    {
        public int KisiID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Cinsiyet { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string EPostaAdresi { get; set; }
        public string EvTelefonu { get; set; }
        public string CepTelefonu { get; set; }
        public string Unvan { get; set; }
        public string IsYeriAdi { get; set; }
    }
}
