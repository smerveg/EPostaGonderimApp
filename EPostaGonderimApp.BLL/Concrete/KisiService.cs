using EPostaGonderimApp.BLL.Abstract;
using EPostaGonderimApp.DAL.Context;
using EPostaGonderimApp.DAL.UnitOfWorks;
using EPostaGonderimApp.EntityLayer.DTOs.FiltreDTOs;
using EPostaGonderimApp.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.BLL.Concrete
{
    public class KisiService : IKisiService
    {
        private readonly IUnitOfWork _unitOfWork;

        public KisiService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Kisi> Add(Kisi entity)
        {
            await _unitOfWork.GetRepository<Kisi>().Add(entity);
                  _unitOfWork.Save();
            return entity;
        }

        public async Task<List<Kisi>> GetAll()
        {
            return await _unitOfWork.GetRepository<Kisi>().GetAll();
        }

        public async Task<List<Kisi>> GetAllByFilter(KisiFilterDTO filter)
        {
            using (var c = new EPostaGonderimContext())
            {
                var kisiList = c.Kisiler.AsQueryable();
                if (filter.Ad != null)
                {
                    kisiList = kisiList.Where(x => x.Ad == filter.Ad);
                }
                if (filter.Soyad != null)
                {
                    kisiList = kisiList.Where(x => x.Soyad == filter.Soyad);
                }
                if (filter.Cinsiyet!=null)
                {
                    kisiList=kisiList.Where(x => x.Cinsiyet == filter.Cinsiyet);
                }
                if (filter.Unvan != null)
                {
                    kisiList = kisiList.Where(x => x.Unvan == filter.Unvan);
                }
                if (filter.IsYeriAdi != null)
                {
                    kisiList = kisiList.Where(x => x.IsYeriAdi == filter.IsYeriAdi);
                }

                return await kisiList.ToListAsync();
            }

        }

    }
}
