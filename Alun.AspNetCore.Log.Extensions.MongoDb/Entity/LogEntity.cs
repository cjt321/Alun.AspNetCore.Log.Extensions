using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alun.AspNetCore.Log.Extensions.MongoDb.Entity
{
    public class LogEntity
    {



        public string Message { get; set; }

        public string LogLevel { get; set; }


        public int EventId { get; set; }

        public string LogName { get; set; }

        public string Detail { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
