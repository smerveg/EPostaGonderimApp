using AutoMapper;
using EPostaGonderimApp.BLL.Abstract;
using EPostaGonderimApp.EntityLayer.DTOs.EPostaDTOs;
using EPostaGonderimApp.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EPostaGonderimApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EPostaController : ControllerBase
    {
        private readonly IEPostaService _service;
        private readonly IMapper _mapper;

        public EPostaController(IEPostaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<List<EPostaListDTO>> GetAllEPosta()
        {
            var ePostaList = await _service.GetAllWithInclude();

            var result = _mapper.Map<List<EPostaListDTO>>(ePostaList);
            return result;
        }

        [HttpGet]
        [Route("getIcerik")]
        public async Task<string> GetIcerik(int id)
        {
            return await _service.GetIcerikById(id);
        }


        [HttpPost]
        [Route("postEPosta")]
       
        public async Task<EPosta> AddEPosta(EPostaDetailDTO entity)
        { 

            var ePosta = _mapper.Map<EPostaDetailDTO, EPosta>(entity);
            var id =  _service.AddToGetId(ePosta);
            if (id!= null)
            {
                _service.AddKisiPostalar(id, entity.Kisiler);
            }

            return ePosta;
        }
    }
}
