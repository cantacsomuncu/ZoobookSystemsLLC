using Microsoft.EntityFrameworkCore;
using ZoobookSystemsLLC.Entities.Concrete;
using ZoobookSystemsLLC.Shared.Data.Concrete.EntityFramework;
using ZoobookSystemsLLC.Data.Abstract;

namespace ZoobookSystemsLLC.Data.Concrete.EntityFramework.Repositories
{
    public class EfEmployeeRepository : EfEntityRepositoryBase<Employee>, IEmployeeRepository
    {
        public EfEmployeeRepository(DbContext context) : base(context)
        {
        }

    }
}
