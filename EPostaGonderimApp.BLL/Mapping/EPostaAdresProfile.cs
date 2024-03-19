using AutoMapper;
using EPostaGonderimApp.EntityLayer.DTOs.EPostaAdresDTOs;
using EPostaGonderimApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.BLL.Mapping
{
    public class EPostaAdresProfile : Profile
    {
        public EPostaAdresProfile()
        {
            CreateMap<EPostaAdres, EPostaAdresListDTO>().ReverseMap();
            CreateMap<EPostaAdres, EPostaAdresDetailDTO>().ReverseMap();
        }
    }
}
