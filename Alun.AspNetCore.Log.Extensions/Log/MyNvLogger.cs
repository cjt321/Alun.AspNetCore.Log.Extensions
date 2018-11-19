using System;
using Alun.AspNetCore.Log.Extensions.Configuration;
using Alun.AspNetCore.Log.Extensions.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;

namespace Alun.AspNetCore.Log.Extensions.Log
{
    /// <summary>
    /// 记录日志类
    /// </summary>
    public class MyNvLogger: ILogger
    {
        public IWriteLog WriteLog { set; private get; }
        public LogConfiguration LogConfiguration { set; private get; }


        public MyNvLogger(string name)
        {
            Name = name;

        }


        public string Name { get; set; }

        internal IExternalScopeProvider ScopeProvider { get; set; }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);

            WriteMessage(logLevel, Name, eventId.Id, message, exception);
        }

        public void WriteMessage(LogLevel logLevel, string logName, int eventId, string message, Exception exception)
        {
            //打印日志
            WriteLog?.WriteLog(logLevel, logName, eventId, message, exception);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            /*if (logLevel == LogLevel.None)
            {
                return false;
            }*/
            bool isWriteLog = false;
            //判断日志是否开启，如果开启则打印日志
            switch (logLevel)
            {
                case LogLevel.Trace:
                    if (LogConfiguration.UseTraceLog)
                        isWriteLog = true;
                    break;
                case LogLevel.Debug:
                    if (LogConfiguration.UseDebugLog)
                        isWriteLog = true;
                    break;
                case LogLevel.Information:
                    if (LogConfiguration.UseInformationLog)
                        isWriteLog = true;
                    break;
                case LogLevel.Warning:
                    if (LogConfiguration.UseWarnLog)
                        isWriteLog = true;
                    break;
                case LogLevel.Error:
                    if (LogConfiguration.UseErrorLog)
                        isWriteLog = true;
                    break;
                case LogLevel.Critical:
                    if (LogConfiguration.UseCriticalLog)
                        isWriteLog = true;
                    break;
            }

            return isWriteLog;
        }

        public IDisposable BeginScope<TState>(TState state) => ScopeProvider?.Push(state) ?? NullScope.Instance;

    }
}