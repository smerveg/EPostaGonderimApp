using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.EntityLayer.Entities
{
    public class EPosta
    {
        public int EPostaID { get; set; }
        public DateTime GonderimTarihi { get; set; }
        public string Konu { get; set; }
        public bool GonderimDurumu { get; set; }
        public string Icerik { get; set; }

        //Navigation Properties

        public int EPostaAdresID { get; set; }
        public EPostaAdres EPostaAdres { get; set; }
        public ICollection<Kisi> Kisiler { get; set; }
    }
}
