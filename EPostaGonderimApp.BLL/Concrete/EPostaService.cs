using EPostaGonderimApp.BLL.Abstract;
using EPostaGonderimApp.DAL.Context;
using EPostaGonderimApp.DAL.UnitOfWorks;
using EPostaGonderimApp.EntityLayer.DTOs.EPostaDTOs;
using EPostaGonderimApp.EntityLayer.DTOs.KisiDTOs;
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
    public class EPostaService : IEPostaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EPostaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<EPosta> Add(EPosta entity)
        {
            await _unitOfWork.GetRepository<EPosta>().Add(entity);
            _unitOfWork.Save();
            return entity;
        }

        public int AddToGetId(EPosta entity)
        {
            using (var c = new EPostaGonderimContext())
            {
                var result = c.Entry(entity);
                result.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                c.SaveChanges();
            }
            return entity.EPostaID;
        }

        public void AddKisiPostalar(int EpostaId, List<KisiListDTO> kisiList)
        {
            using (var c = new EPostaGonderimContext())
            {
                EPosta eposta = new EPosta { EPostaID = EpostaId };
                eposta.Kisiler = new List<Kisi>();
                c.EPostalar.Add(eposta);
                c.EPostalar.Attach(eposta);


                foreach (var item in kisiList)
                {
                    Kisi kisi = new Kisi { KisiID = item.KisiID };
                    c.Kisiler.Add(kisi);
                    c.Kisiler.Attach(kisi);


                    eposta.Kisiler.Add(kisi);
                }

                 c.SaveChangesAsync();

            }
        }

        public async Task<List<EPosta>> GetAll()
        {
            return await _unitOfWork.GetRepository<EPosta>().GetAll();
        }

        public async Task<List<EPostaListDTO>> GetAllWithInclude()
        {
            List<EPostaListDTO> includeList = new List<EPostaListDTO>();
            using (var c = new EPostaGonderimContext())
            {
                var liste= await c.EPostalar.Include("EPostaAdres").ToListAsync();

                foreach (var item in liste)
                {
                    EPostaListDTO epList = new EPostaListDTO();
                    epList.EPostaAdresID = item.EPostaAdres.EPostaAdresID;
                    epList.EPostaID = item.EPostaID;
                    epList.Konu = item.Konu;
                    epList.Adres = item.EPostaAdres.Adres;
                    includeList.Add(epList);
                   
                }
            }
            return includeList;
        }

        public async Task<string> GetIcerikById(int id)
        {
            using (var c = new EPostaGonderimContext())
            {
                var posta = await c.EPostalar.Where(e => e.EPostaID == id).FirstOrDefaultAsync();

                return posta.Icerik;
            }
        }
    }
}
