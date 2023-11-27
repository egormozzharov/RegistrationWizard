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
                user.Id = Guid.NewGuid();
                _logger.LogInformation("Attempting to register user: {User}", user);
                await _userService.SaveUserAsync(user);
                _logger.LogInformation("User registration successful: {User}", user);
                return Ok();
            }
            _logger.LogWarning("User registration failed due to invalid model state: {ModelState}", ModelState);
            return BadRequest(ModelState);
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateUser(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userService.GetUserAsync(user.Email);
                if (existingUser != null)
                {
                    _logger.LogInformation("User validation failed: User already exists: {User}", user);
                    return BadRequest("User already exists");
                }
                _logger.LogInformation("User validation successful: {User}", user);
                return Ok();
            }
            _logger.LogWarning("User validation failed due to invalid model state: {ModelState}", ModelState);
            return BadRequest(ModelState);
        }
    }
}
