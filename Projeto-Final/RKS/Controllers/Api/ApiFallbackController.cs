using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Api
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)] // 🔥 Swagger safety
    public class ApiFallbackController : ControllerBase
    {
        // =========================================
        // 🔥 Catch-all for invalid API routes
        // Example: /api/xx, /api/anything/wrong
        // =========================================
        [Route("api/{**catchAll}")]
        public IActionResult HandleInvalidApiRoute()
        {
            return NotFound(new
            {
                error = "Invalid API endpoint",
                path = HttpContext.Request.Path.ToString(),
                suggestion = "Check /swagger for valid endpoints",
                status = 404
            });
        }
    }
}