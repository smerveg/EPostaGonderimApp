using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.EntityLayer.Entities
{
    public class EPostaAdres
    {
        public int EPostaAdresID { get; set; }
        public string Adres { get; set; }
        public string MailSunucuAdres { get; set; }
        public string KullaniciAd { get; set; }
        public string Sifre { get; set; }
        public string Port { get; set; }

        //
        public ICollection<EPosta> EPostalar { get; set; }
    }
}
