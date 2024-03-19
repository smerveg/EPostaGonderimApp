using AutoMapper;
using EPostaGonderimApp.BLL.Abstract;
using EPostaGonderimApp.EntityLayer.DTOs.FiltreDTOs;
using EPostaGonderimApp.EntityLayer.DTOs.KisiDTOs;
using EPostaGonderimApp.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class KisiController : ControllerBase
    {
        private readonly IKisiService _service;
        private readonly IMapper _mapper;

        public KisiController(IKisiService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<List<KisiListDTO>> GetAllKisi()
        {
            var kisiList = await _service.GetAll();

            var result= _mapper.Map<List<KisiListDTO>>(kisiList);
            return result;
        }

        [HttpGet]
        [Route("getAllByFilter")]
        public async Task<List<Kisi>> GetAllKisiByFilter([FromQuery]KisiFilterDTO filter)
        {
            return await _service.GetAllByFilter(filter);
           
        }

        [HttpPost]
        [Route("postKisi")]
        [AllowAnonymous]
        public async Task<Kisi> AddKisi(KisiDetailDTO entity)
        {
            var kisi = _mapper.Map<KisiDetailDTO,Kisi>(entity);
            return await _service.Add(kisi);
        }
    }
}
