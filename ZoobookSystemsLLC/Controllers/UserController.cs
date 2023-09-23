using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ZoobookSystemsLLC.Entities.Concrete;
using ZoobookSystemsLLC.Entities.Dtos;
using ZoobookSystemsLLC.Services.Abstract;

namespace ZoobookSystemsLLC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IJWTService _jWTManager;

        public UserController(UserManager<User> userManager, IJWTService jWTManager)
        {
            _userManager = userManager;
            _jWTManager = jWTManager;
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return Ok(0);
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
                return Ok(0);

            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Email, user.Email),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            string jwt = _jWTManager.GenerateToken(authClaims);
            return Ok(jwt);
        }       
    }
}
