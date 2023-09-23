using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ZoobookSystemsLLC.Services.Abstract
{
    public interface IJWTService
    {
        public string GenerateToken(IEnumerable<Claim> claims);
    }
}
