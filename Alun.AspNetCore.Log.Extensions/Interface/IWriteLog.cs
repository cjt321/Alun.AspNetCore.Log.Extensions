using System;
using Microsoft.Extensions.Logging;

namespace Alun.AspNetCore.Log.Extensions.Interface
{
    /// <summary>
    /// 记录日志接口
    /// </summary>
    public interface IWriteLog
    {

        void WriteLog(LogLevel logLevel, string logName, int eventId, string message, Exception exception);

    }
}
