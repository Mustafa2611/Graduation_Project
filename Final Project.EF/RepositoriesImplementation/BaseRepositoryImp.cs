using Final_Project.Core.Models;
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

        public T Get(Expression<Func<T, bool>> match, string[] includes = null)
        {
            //var entity = _context.Set<T>().Find(id);
            //if (entity == null)
            //    return null;
            //_context.Entry(entity).State= EntityState.Detached;


            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            var entity = query.FirstOrDefault(match);
            if (entity == null)
                return null;

            _context.Entry(entity).State= EntityState.Detached;

            return entity;
        }

        public IEnumerable<T> GetAll(string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.ToList();
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

        public College GetCollege(Expression<Func<College,bool>> match , string[] Includes = null)
        {
         
            IQueryable<College> query = _context.Set<College>();
            if(Includes != null)
                foreach (var Include in Includes)
                    query = query.Include(Include);

            var entity = query.FirstOrDefault(match);
            if (entity == null)
                return null;
            return entity;
        }
    }
}
