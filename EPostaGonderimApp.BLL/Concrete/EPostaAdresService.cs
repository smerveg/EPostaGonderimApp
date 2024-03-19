using EPostaGonderimApp.BLL.Abstract;
using EPostaGonderimApp.DAL.UnitOfWorks;
using EPostaGonderimApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.BLL.Concrete
{
    public class EPostaAdresService : IEPostaAdresService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EPostaAdresService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<EPostaAdres> Add(EPostaAdres entity)
        {
            await _unitOfWork.GetRepository<EPostaAdres>().Add(entity);
            _unitOfWork.Save();
            return entity;
        }

        public async Task<List<EPostaAdres>> GetAll()
        {
            return await _unitOfWork.GetRepository<EPostaAdres>().GetAll();
        }


    }
}
