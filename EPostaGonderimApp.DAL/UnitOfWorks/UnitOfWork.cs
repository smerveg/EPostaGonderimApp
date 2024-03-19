using EPostaGonderimApp.DAL.Context;
using EPostaGonderimApp.DAL.Repositories.Abstract;
using EPostaGonderimApp.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EPostaGonderimContext context;

        public UnitOfWork(EPostaGonderimContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(context);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
