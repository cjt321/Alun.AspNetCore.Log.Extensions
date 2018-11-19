using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Alun.AspNetCore.Log.Extensions.Interface
{
    /// <summary>
    /// default 记录日志
    /// </summary>
    public class DefaultWriteLog:IWriteLog
    {
        /// <summary>
        /// 打印日志到Debug控制台
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="logName"></param>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void WriteLog(LogLevel logLevel, string logName, int eventId, string message, Exception exception)
        {
            WriteLog($"In DefaultWriteLog, {logName}-{logLevel}, message:{message}, exception:{exception?.Message}, detail:{exception?.InnerException?.Message}");   
        }

        private void WriteLog(string msg)
        {
            Debug.WriteLine(msg);
        }
    }
}
