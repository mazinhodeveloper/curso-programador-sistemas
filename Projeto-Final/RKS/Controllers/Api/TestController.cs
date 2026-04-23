using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Api
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Swagger OK");
        }
    }
}