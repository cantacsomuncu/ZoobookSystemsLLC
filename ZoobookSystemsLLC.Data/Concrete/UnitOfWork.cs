using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoobookSystemsLLC.Data.Abstract;
using ZoobookSystemsLLC.Data.Concrete.EntityFramework.Contexts;
using ZoobookSystemsLLC.Data.Concrete.EntityFramework.Repositories;

namespace ZoobookSystemsLLC.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZoobookSystemsLLCDbContext _context;
        private EfEmployeeRepository _employeeRepository;

        public UnitOfWork(ZoobookSystemsLLCDbContext context)
        {
            _context = context;
        }

        public IEmployeeRepository Employees => _employeeRepository ?? new EfEmployeeRepository(_context);
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
