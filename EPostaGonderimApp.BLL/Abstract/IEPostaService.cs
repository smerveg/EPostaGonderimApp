using EPostaGonderimApp.EntityLayer.DTOs.EPostaDTOs;
using  EPostaGonderimApp.EntityLayer.DTOs.KisiDTOs;
using EPostaGonderimApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.BLL.Abstract
{
    public interface IEPostaService:IGenericService<EPosta>
    {
        int AddToGetId(EPosta entity);
        void AddKisiPostalar(int EPostaId, List<KisiListDTO> kisiList);
        Task<List<EPostaListDTO>> GetAllWithInclude();
        Task<string> GetIcerikById(int id);
    }
}
