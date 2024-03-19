using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.EntityLayer.DTOs.KisiDTOs
{
    public class KisiListDTO
    {
        public int KisiID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string EPostaAdresi { get; set; }
    }
}
