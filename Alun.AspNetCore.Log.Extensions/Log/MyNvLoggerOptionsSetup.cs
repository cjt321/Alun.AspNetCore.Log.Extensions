using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace Alun.AspNetCore.Log.Extensions.Log
{
    /// <summary>
    /// Log配置类
    /// </summary>
    internal class MyNvLoggerOptionsSetup : ConfigureFromConfigurationOptions<MyNvLoggerOptions>
    {
        public MyNvLoggerOptionsSetup(ILoggerProviderConfiguration<MyNvLogProvider> providerConfiguration)
            : base(providerConfiguration.Configuration)
        {
        }
    }
}
