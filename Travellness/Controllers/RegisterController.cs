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
        private readonly ILoginManager loginManager;

        public RegisterController(

            ILogger<RegisterController> logger, IRegisterManager registerManager,
            ILoginManager loginManager
            )
        {
            this.logger = logger;
            this.registerManager = registerManager;
            this.loginManager = loginManager;
        }

        [HttpPost(Name = "User Register")]
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

                logger.LogError(ex, "Error during registration.");


                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}", Name = "GetRegister")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var registeredUser = await registerManager.GetRegisterAsync(id);

                if (registeredUser == null)
                {
                    return NotFound();
                }

                return Ok(registeredUser);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error during retrieval.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("all", Name = "GetAllRegisters")]
        public async Task<IActionResult> GetAll()
        {

            try
            {

                var getAll = await registerManager.GetAllRegistersAsync();

                if (getAll == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(getAll);
                }
            }

            catch (Exception ex)
            {
                logger.LogError(ex, "Error during retrieval.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("Login", Name = "UserLogin")]
        public async Task<IActionResult> Post(LoginModel loginModel)
        {
            try
            {
                var result = await loginManager.AuthenticateAsync(loginModel);

                if (result.Succeeded)
                {
                    return Ok("Login successful"); 
                }
                else
                {
                    return Unauthorized(result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}




    


