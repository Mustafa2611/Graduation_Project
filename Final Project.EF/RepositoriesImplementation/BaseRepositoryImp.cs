using Final_Project.EF.Configuration;
using FinalProject.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.EF.RepositoriesImplementation
{
    public class BaseRepositoryImp<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepositoryImp(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public T Get(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
                return null;
            _context.Entry(entity).State= EntityState.Detached;
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            var entity = _context.Set<T>().ToList();
            if (entity == null)
                return null;

            return entity;
        }

        public T Update(T entity)
        {
            if (entity == null)
                return null;
          _context.Set<T>().Update(entity);
            return entity;
        }

        public T Delete(int id)
        {
           T entity = _context.Set<T>().Find(id);
            if (entity == null)
                return null;
            _context.Set<T>().Remove(entity);
            return entity;
        }

    }
}
