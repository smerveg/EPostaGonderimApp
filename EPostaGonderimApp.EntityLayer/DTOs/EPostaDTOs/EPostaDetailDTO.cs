using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPostaGonderimApp.EntityLayer.DTOs.KisiDTOs;

namespace EPostaGonderimApp.EntityLayer.DTOs.EPostaDTOs
{
    public class EPostaDetailDTO
    {
        public int EPostaID { get; set; }
        public DateTime GonderimTarihi { get; set; }
        public string Konu { get; set; }
        public bool GonderimDurumu { get; set; }
        public string Icerik { get; set; }
        public int EPostaAdresID { get; set; }
        public ICollection<int> KisiIdleri { get; set; }
        public List<KisiListDTO> Kisiler { get; set; }
    }
}
