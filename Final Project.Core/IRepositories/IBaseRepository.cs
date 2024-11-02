using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        T Create(T entity);

        T Get(int id);

        IEnumerable<T> GetAll();

        T Update(T entity);

        T Delete(int id);
    }
}
