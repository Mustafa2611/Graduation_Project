using Final_Project.EF.Configuration;
using Final_Project.EF.RepositoriesImplementation;
using FinalProject.Core;
using FinalProject.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.EF
{
    public class UnitOfWorkImp : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWorkImp(ApplicationDbContext context)
        {
             _context = context;
            Events = new EventRepositoryImp(_context);
            News = new NewsRepositoryImp(_context);
        }

        public IEventRepository Events { get; private set; }

        public INewsRepository News { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
