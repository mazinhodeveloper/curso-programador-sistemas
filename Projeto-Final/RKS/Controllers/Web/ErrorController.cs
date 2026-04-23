using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace API.Controllers.Web
{
    [ApiExplorerSettings(IgnoreApi = true)] // 🔥 Swagger safety
    
    public class ErrorController : Controller
    {
        [Route("error/{statusCode}")]
        public IActionResult HandleError(int statusCode)
        {
            var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            var originalPath = feature?.OriginalPath ?? HttpContext.Request.Path.ToString();

            if (statusCode == 404)
            {
                // ⬇️⬇️⬇️ IT GOES RIGHT HERE, INSIDE THE 404 CHECK ⬇️⬇️⬇️
                if (Request.Headers["Accept"].ToString().Contains("application/json"))
                {
                    return NotFound(new
                    {
                        error = "Not Found",
                        path = originalPath
                    });
                }
                // ⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️⬆️

                // If it's NOT a JSON request (it's a browser), it continues to here:
                return View("NotFound", originalPath);
            }

            return View("Error");
        }
    }
}