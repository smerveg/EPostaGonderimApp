using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EPostaGonderimApp.DAL.Repositories.Abstract
{
    public interface IGenericRepository<T> where T:class
    {
        Task<List<T>> GetAll();
        Task<T> Add(T entity);

    }
}
