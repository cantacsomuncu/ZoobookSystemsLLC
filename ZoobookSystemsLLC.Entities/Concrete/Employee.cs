using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoobookSystemsLLC.Shared.Entities.Abstract;

namespace ZoobookSystemsLLC.Entities.Concrete
{
    public class Employee:EntityBase,IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
