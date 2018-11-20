using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Alun.AspNetCore.Log.Extensions.Interface;
using Alun.AspNetCore.Log.Extensions.MongoDb.Entity;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Alun.AspNetCore.Log.Extensions.MongoDb.Log
{

    /// <summary>
    /// mongodb 记录日志
    /// </summary>
    public class MongoDbWriteLog:IWriteLog
    {
        private readonly IMongoCollection<LogEntity> _logEntityCollection;

        public MongoDbWriteLog(IMongoDatabase mongoDatabase)
        {
            _logEntityCollection = mongoDatabase.GetCollection<LogEntity>(typeof(LogEntity).Name);
        }

        /// <summary>
        /// 打印日志到mongodb控制台
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="logName"></param>
        /// <param name="eventId"></param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void WriteLog(LogLevel logLevel, string logName, int eventId, string message, Exception exception)
        {
            //这里开始mongodb的记录逻辑
            _logEntityCollection.InsertOne(new LogEntity(){CreateTime = DateTime.Now,Detail = exception?.StackTrace, EventId = eventId, LogLevel = logLevel.ToString(), LogName = logName, Message = message});

        }
    }
}
