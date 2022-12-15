using MicroserviceSkyWalking.Model;
using Microsoft.AspNetCore.Mvc;
using SkyApm.Tracing;
using SkyApm.Tracing.Segments;

namespace MicroserviceSkyWalking.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IEntrySegmentContextAccessor _segContext;

        public HomeController(IEntrySegmentContextAccessor segContext)
        {
            _segContext = segContext;
        }
        [HttpGet("GetSkyWalkingLog")]
        public IActionResult GetSkyWalkingLog()
        {
            //获取全局traceId
            var traceId = _segContext.Context.TraceId;
            _segContext.Context.Span.AddLog(LogEvent.Message("自定义日志1"));
            Thread.Sleep(1000);
            _segContext.Context.Span.AddLog(LogEvent.Message("自定义日志2"));
            return Ok(traceId);
        }
        [HttpGet("GetUser")]
        public async Task<string> GetUser(string userId)
        {
            var client = new HttpClient();
            //调用Service2
            var response = await client.GetAsync($"http://localhost:5272/api/UserInfo/GetUserInfo?userId={userId}");
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }


        /// <summary>
        /// 故意报错测试告警
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("Error")]
        public string Error()
        {
            //故意报错
            throw new Exception($"出错啦:{DateTime.Now}");
        }
        /// <summary>
        /// 告警
        /// </summary>
        /// <param name="msgs"></param>
        [HttpPost("AlarmMsg")]
        public void AlarmMsg([FromBody] List<AlarmMsg> msgs)
        {
            string msg = $"{DateTime.Now},触发告警：";
            msg += msgs.FirstOrDefault()?.alarmMessage;
            Console.WriteLine(msg);
            //todo 发邮件或发短信
        }
    }
}
