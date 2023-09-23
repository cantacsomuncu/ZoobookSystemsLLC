using ZoobookSystemsLLC.Entities.Concrete;
using ZoobookSystemsLLC.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoobookSystemsLLC.Data.Abstract
{
    public interface IEmployeeRepository : IEntityRepository<Employee>
    {
    }
}
