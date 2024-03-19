using EPostaGonderimApp.EntityLayer.DTOs.EPostaAdresDTOs;
using EPostaGonderimApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.EntityLayer.DTOs.EPostaDTOs
{
    public class EPostaListDTO
    {
        public int EPostaID { get; set; }
        public string Konu { get; set; }
        public int EPostaAdresID { get; set; }
        public string Adres { get; set; }
    }
}
