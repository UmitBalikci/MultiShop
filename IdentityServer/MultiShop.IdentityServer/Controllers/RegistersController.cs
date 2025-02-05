using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDtos)
        {
            var user = new ApplicationUser
            {
                UserName = userRegisterDtos.UserName,
                Email = userRegisterDtos.Email,
                FirstName = userRegisterDtos.FirstName,
                LastName = userRegisterDtos.LastName
            };

            var result = await _userManager.CreateAsync(user, userRegisterDtos.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
    }
}
