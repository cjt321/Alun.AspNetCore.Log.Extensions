# 使用类库
目前本人在微软原生日志类库的基础之上，写了一个Log的扩展。目的是为了更好地扩展Log。当我们需要自定义自己的Log记录方式时，使用此库是你的明智选择。

# 类库地址信息
            Nuget地址：https://www.nuget.org/packages/Alun.AspNetCore.Log.Extensions
            GitHub开源地址：https://github.com/cjt321/Alun.AspNetCore.Log.Extensions


# 怎么使用此类库？
首先，引用Nuget包的地址。在项目启动时，添加Log的配置。

            services.AddLogging(cfg =>
                        {
                            cfg.AddNvLog(new LogConfiguration(){UseTraceLog = false, UseDebugLog = true, UseInformationLog = true, UseErrorLog = true, UseCriticalLog = true})
                                .AddDefaultWriteLog();
                        });
                        
在AddNvLog方法中，Log级别可配置：UseTraceLog、UseDebugLog、UseInformationLog、UseErrorLog、UseCriticalLog。 如果为true，则执行相应的Log。
