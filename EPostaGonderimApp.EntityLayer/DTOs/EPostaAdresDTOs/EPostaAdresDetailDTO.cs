using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.EntityLayer.DTOs.EPostaAdresDTOs
{
    public class EPostaAdresDetailDTO
    {
        public int EPostaAdresID { get; set; }
        public string Adres { get; set; }
        public string MailSunucuAdres { get; set; }
        public string KullaniciAd { get; set; }
        public string Sifre { get; set; }
        public string Port { get; set; }
    }
}
