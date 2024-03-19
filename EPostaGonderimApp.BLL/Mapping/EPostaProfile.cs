using AutoMapper;
using EPostaGonderimApp.EntityLayer.DTOs.EPostaDTOs;
using EPostaGonderimApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.BLL.Mapping
{
    public class EPostaProfile : Profile
    {
        public EPostaProfile()
        {
            CreateMap<EPosta, EPostaListDTO>().ReverseMap();
            CreateMap<EPosta, EPostaDetailDTO>().ReverseMap();
        }
    }
}
