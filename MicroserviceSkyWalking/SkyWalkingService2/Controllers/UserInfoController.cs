using Microsoft.AspNetCore.Mvc;
using SkyApm.Tracing;
using SkyApm.Tracing.Segments;

namespace SkyWalkingService2.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserInfoController : Controller
    {
        private readonly IEntrySegmentContextAccessor _segContext;

        public UserInfoController(IEntrySegmentContextAccessor segContext)
        {
            _segContext = segContext;
        }
        [HttpGet("GetUserInfo")]
        public string GetUserInfo(string userId)
        {
            var data = $"userId:{userId},userName:Evan";
            _segContext.Context.Span.AddLog(LogEvent.Message(data));
            return data;
        }
    }
}
