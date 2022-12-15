using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWalkingExtensions
{
    /// 注册发现相关参数
    /// </summary>
    public class ConsulOption
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 服务ip
        /// </summary>
        public string ServiceIp { get; set; }
        /// <summary>
        /// 服务端口
        /// </summary>
        public int ServicePort { get; set; }

        /// <summary>
        /// 服务健康检查地址
        /// </summary>
        public string ServiceHealthCheck { get; set; }

        /// <summary>
        /// Consul 地址
        /// </summary>
        public string Address { get; set; }

    }
}
