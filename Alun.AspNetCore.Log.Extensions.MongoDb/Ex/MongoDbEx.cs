using System;
using System.Collections.Generic;
using System.Text;
using Alun.AspNetCore.Log.Extensions.Interface;
using Alun.AspNetCore.Log.Extensions.MongoDb.Log;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Alun.AspNetCore.Log.Extensions.MongoDb.Ex
{
    /// <summary>
    /// log的mongodb扩展类
    /// </summary>
    public static class MongoDbEx
    {

        /// <summary>
        /// 添加mongdob
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="connectionString"></param>
        /// <param name="dataBaseName"></param>
        public static ILoggingBuilder AddMongoDbLog(this ILoggingBuilder builder, string connectionString, string dataBaseName)
        {
            //初始化mongodb
            var database = new MongoClient(connectionString).GetDatabase(dataBaseName);
            builder.Services.AddSingleton<IMongoDatabase>(database);
            //添加mongodb的writelog
            builder.Services.TryAddTransient<IWriteLog, MongoDbWriteLog>();

            return builder;
        }
    }
}
