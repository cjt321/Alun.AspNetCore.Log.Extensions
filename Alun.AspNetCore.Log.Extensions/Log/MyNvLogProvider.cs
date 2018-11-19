using System.Collections.Concurrent;
using Alun.AspNetCore.Log.Extensions.Configuration;
using Alun.AspNetCore.Log.Extensions.Interface;
using Microsoft.Extensions.Logging;

namespace Alun.AspNetCore.Log.Extensions.Log
{
    /// <summary>
    /// log提供者
    /// </summary>
    public class MyNvLogProvider : ILoggerProvider, ISupportExternalScope
    {

        /// <summary>
        /// 保存不同类的log的集合。
        /// </summary>
        private readonly ConcurrentDictionary<string, MyNvLogger> _loggers = new ConcurrentDictionary<string, MyNvLogger>();

        private readonly IWriteLog _writeLog;
        private readonly LogConfiguration _logConfiguration;

        public MyNvLogProvider(IWriteLog writeLog, LogConfiguration logConfiguration)
        {
            _writeLog = writeLog;
            _logConfiguration = logConfiguration;
        }

        public void Dispose()
        {
            
        }

        /// <summary>
        /// 创建一个新的log，外面的ILog怎么识别到MyNvLogger呢？就是通过此方法识别到log
        /// </summary>
        /// <param name="categoryName">The category name for messages produced by the logger.</param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }

        public void SetScopeProvider(IExternalScopeProvider scopeProvider)
        {
        }


        private MyNvLogger CreateLoggerImplementation(string name)
        {
            return new MyNvLogger(name){WriteLog = _writeLog, LogConfiguration = _logConfiguration};

        }

    }
}
