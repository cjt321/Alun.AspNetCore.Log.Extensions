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


# 扩展类库
当我们需要扩展日志以自己的逻辑记录到文件、队列、MySql、Mongodb等持久化时，可以扩展类库，扩展也很简单。
对于mongodb扩展类库，nuget上也有个包，但是此包只能满足一般的需求，对于复杂的需求还不能满足，需要用户自己扩展自己的逻辑。

## 以Alun.AspNetCore.Log.Extensions.MongoDb为例
此包是对Log保存在Mongodb中。
此包在Nuget：https://www.nuget.org/packages/Alun.AspNetCore.Log.Extensions.MongoDb

1）安装Alun.AspNetCore.Log.Extensions的nuget，因为这里需要用到mongodb，所以安装MongoDB.Driver。

2）添加mongodb的writelog类，来继承IWriteLog。
![alt text](http://alun-image.oss-cn-shenzhen.aliyuncs.com/github/Alun.AspNetCore.Log.Extensions/2.png)

注意，我们在WriteLog方法中写日志，记录到mongodb中，此方法实现的是我们需要自定义的逻辑。这里把日志通过实体方法，持久化。
为何要继承IWriteLog？因为我们需要用到自己的逻辑，继承此类为了使用DI/IOC时，可以直接注入继承IWriteLog的类。
众所周知，使用DI/IOC时。有一好处，所有的对象都存放在容器上，如果需要修改容器里面对象，则可以通过注入的方式修改。对于继承，我们可以注入接口与实现类的方式，灵活变更实现类。
所以，我们需要在容器上初始化IWriteLog与MongoDbWriteLog的关系。

3）添加扩展配置

![alt text](http://alun-image.oss-cn-shenzhen.aliyuncs.com/github/Alun.AspNetCore.Log.Extensions/3.png)

我们主要看初始化mongodb的writelog配置，这里在容器中注入了IWriteLog, MongoDbWriteLog的继承关系。
如何使用？
很简单，可查看WebApplicationDemo.MongoDb中，加入Mongdb的配置即可：

![alt text](http://alun-image.oss-cn-shenzhen.aliyuncs.com/github/Alun.AspNetCore.Log.Extensions/4.png)

在demo中，TestController记录了日志，可以在MongoDb中看到相应的日志了：

![alt text](http://alun-image.oss-cn-shenzhen.aliyuncs.com/github/Alun.AspNetCore.Log.Extensions/5.png)

上图中，可以看到还有其它日志，其它日志是属于.Net原生框架启动、访问API使用到。

扩展类库的原理
使用依赖注入，注入我们需要的Log逻辑类，如Mongdb中的MongoDbWriteLog。所以，需要扩展，只需要继承IWriteLog，并且注入，就能扩展类了，很方便。
