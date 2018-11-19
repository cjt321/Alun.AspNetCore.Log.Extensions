using System;
using Alun.AspNetCore.Log.Extensions.Configuration;
using Alun.AspNetCore.Log.Extensions.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace Alun.AspNetCore.Log.Extensions.Log
{
    public static class LogEx
    {
        /// <summary>
        /// 添加自定义Log。默认只开启error及以上级别log
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="logConfiguration"></param>
        /// <returns></returns>
        public static ILoggingBuilder AddNvLog(this ILoggingBuilder builder, LogConfiguration logConfiguration=null)
        {
            builder.AddConfiguration();

            if(logConfiguration == null)
                logConfiguration = new LogConfiguration();
            builder.Services.TryAddSingleton(logConfiguration);

            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, MyNvLogProvider>());
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IConfigureOptions<MyNvLoggerOptions>, MyNvLoggerOptionsSetup>());
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IOptionsChangeTokenSource<MyNvLoggerOptions>, LoggerProviderOptionsChangeTokenSource<MyNvLoggerOptions, MyNvLogProvider>>());

            return builder;
        }


        public static ILoggingBuilder AddDefaultWriteLog(this ILoggingBuilder builder)
        {
            builder.Services.TryAddTransient<IWriteLog, DefaultWriteLog>();
            return builder;
        }

    }
}
