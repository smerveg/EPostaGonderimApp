using AutoMapper;
using EPostaGonderimApp.BLL.Abstract;
using EPostaGonderimApp.EntityLayer.DTOs.EPostaAdresDTOs;
using EPostaGonderimApp.EntityLayer.Entities;
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
    public class EPostaAdresController : ControllerBase
    {
        private readonly IEPostaAdresService _service;
        private readonly IMapper _mapper;

        public EPostaAdresController(IEPostaAdresService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<List<EPostaAdresListDTO>> GetAllKisi()
        {
            var kisiList = await _service.GetAll();

            var result = _mapper.Map<List<EPostaAdresListDTO>>(kisiList);
            return result;
        }


        [HttpPost]
        [Route("postAdres")]
        public async Task<EPostaAdres> AddEPostaAdres(EPostaAdresDetailDTO entity)
        {
            var adres = _mapper.Map<EPostaAdresDetailDTO, EPostaAdres>(entity);
            return await _service.Add(adres);
        }
    }
}
