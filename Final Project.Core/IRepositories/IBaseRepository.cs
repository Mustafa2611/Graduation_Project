using Final_Project.Core.Models;
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

        T Get(Expression<Func<T,bool>> match , string[] includes = null);

        College GetCollege(Expression<Func<College,bool>> match , string[] includes = null);

        IEnumerable<T> GetAll(string[] includes = null);

        T Update(T entity);

        T Delete(int id);
    }
}
