using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Api
{
    [ApiController]
    [Route("api")]
    public class ApiRootController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                name = "RKS API",
                version = "1.0",
                swagger = "/swagger"
            });
        }
    }
}
