using Microsoft.AspNetCore.Mvc;
using PasswordValidator.Services;

namespace PasswordValidator.Controllers
{
    [Route("api/[controller]")]
    public class PasswordController : Controller
    {
        private readonly IPasswordService _passwordService;

        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [HttpGet("{value}/is-valid")]
        public ActionResult<bool> IsValid(string value)
        {
            if(string.IsNullOrEmpty(value))
                return BadRequest();

            return _passwordService.IsValid(value);
        }
    }
}
