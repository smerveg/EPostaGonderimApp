using EPostaGonderimApp.DAL.Context;
using EPostaGonderimApp.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.DAL.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        private readonly EPostaGonderimContext _context;

        public GenericRepository(EPostaGonderimContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }
    }
}
