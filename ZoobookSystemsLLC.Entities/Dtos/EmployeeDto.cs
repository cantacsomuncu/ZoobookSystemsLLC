using ZoobookSystemsLLC.Shared.Entities.Abstract;
using ZoobookSystemsLLC.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoobookSystemsLLC.Entities.Concrete;

namespace ZoobookSystemsLLC.Entities.Dtos
{
    public class EmployeeDto : DtoGetBase
    {
        public Employee Employee { get; set; }
    }
}
