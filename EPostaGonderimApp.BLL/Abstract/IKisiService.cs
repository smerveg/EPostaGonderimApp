
using EPostaGonderimApp.EntityLayer.DTOs.FiltreDTOs;
using EPostaGonderimApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.BLL.Abstract
{
    public interface IKisiService:IGenericService<Kisi>
    {
        Task<List<Kisi>> GetAllByFilter(KisiFilterDTO filter);
    }
}
