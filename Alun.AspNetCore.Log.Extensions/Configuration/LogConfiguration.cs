using System;
using System.Collections.Generic;
using System.Text;

namespace Alun.AspNetCore.Log.Extensions.Configuration
{
    /// <summary>
    /// log配置类
    /// </summary>
    public class LogConfiguration
    {

        /// <summary>
        /// 是否使用Trace Log，默认为false
        /// </summary>
        public bool UseTraceLog { get; set; }

        /// <summary>
        /// 是否使用Debug Log，默认为false
        /// </summary>
        public bool UseDebugLog { get; set; }

        /// <summary>
        /// 是否使用Information Log，默认为false
        /// </summary>
        public bool UseInformationLog { get; set; }

        /// <summary>
        /// 是否使用Warn Log，默认为false
        /// </summary>
        public bool UseWarnLog { get; set; }

        /// <summary>
        /// 是否使用Error Log，默认为true
        /// </summary>
        public bool UseErrorLog { get; set; }

        /// <summary>
        /// 是否使用Critical Log，默认为true
        /// </summary>
        public bool UseCriticalLog { get; set; }


        public LogConfiguration()
        {
            UseDebugLog = false;
            UseInformationLog = false;
            UseWarnLog = false;
            UseErrorLog = true;
            UseCriticalLog = true;
        }


    }
}
