using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoobookSystemsLLC.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IEmployeeRepository Employees { get; }
        Task<int> SaveAsync();
    }
}
