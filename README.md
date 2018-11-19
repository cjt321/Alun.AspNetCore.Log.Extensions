# Nuget地址
https://www.nuget.org/packages/Alun.AspNetCore.Log.Extensions

# 说明
此类库是对Asp Net原生的Log做扩展。
如果你需要自定义Log写日志，把Log写到MongoDB、队列。恭喜你，你不需要对原生的Log做任何代码上的改变，只需要加上配置即可。

# 使用说明
1）引用Nuget包

2）在项目启动时，加上log的初始化：

            services.AddLogging(cfg =>
            {
            
                cfg.AddNvLog(new LogConfiguration(){UseTraceLog = false, UseDebugLog = true, UseInformationLog = true, UseErrorLog = true, UseCriticalLog = true})
                    .AddDefaultWriteLog();
                    
            });


AddNvLog是指加上自定义Log，固定的写法。后面的AddDefaultWriteLog是自定义的Log。如果自定义了Mongodb的Log，可以扩展MongoDB的Log方法。

可看DEMO启动配置Log的方法。

这里的Log级别可配置：UseTraceLog、UseDebugLog、UseInformationLog、UseErrorLog、UseCriticalLog。 如果为True，则执行Log相应的逻辑。

