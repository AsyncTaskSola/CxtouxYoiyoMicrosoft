using Microsoft.AspNetCore.Mvc;

namespace MicroserviceSkyWalking.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class HealthController : Controller
    {
        [HttpGet("/HealthCheck")]
        public IActionResult Check() => Ok("ok");
    }
}
