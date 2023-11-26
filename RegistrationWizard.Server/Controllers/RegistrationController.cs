using Microsoft.AspNetCore.Mvc;
using RegistrationWizard.Server.Models;
using RegistrationWizard.Server.Services;

namespace RegistrationWizard.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(
            IUserService userService,
            ILogger<RegistrationController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Attempting to register user: {User}", user);
                await _userService.SaveUserAsync(user);
                _logger.LogInformation("User registration successful: {User}", user);
                return Ok();
            }
            _logger.LogWarning("User registration failed due to invalid model state: {ModelState}", ModelState);
            return BadRequest(ModelState);
        }
    }
}
