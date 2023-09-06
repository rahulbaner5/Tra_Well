using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travellness.Entities.Modal;
using Travellness.WebApi.Core;

namespace Travellness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterManager registerManager;

        private readonly ILogger<RegisterController> logger;


        public RegisterController(

            ILogger<RegisterController> logger, IRegisterManager registerManager
            )
        {
            this.logger = logger;
            this.registerManager = registerManager;
        }

        [HttpPost(Name = "Company Register")]
        public async Task<IActionResult> Post(Register register)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

              
                await registerManager.AddRegisterAsync(register);

               
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                logger.LogError(ex, "Error during registration.");

                // Return an internal server error response
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

