
using AutoMapper;
using EPostaGonderimApp.EntityLayer.DTOs.KisiDTOs;
using EPostaGonderimApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.BLL.Mapping
{
    public class KisiProfile:Profile
    {
        public KisiProfile()
        {
            CreateMap<Kisi, KisiListDTO>().ReverseMap();
            CreateMap<Kisi, KisiDetailDTO>().ReverseMap();
        }
    }
}
