using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplicationDemo.Controllers
{
    public class TestController: Controller
    {

        private readonly ILogger _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogTrace("##################################Trace##################################");
            _logger.LogDebug("##################################Debug##################################");
            _logger.LogInformation("##################################Information##################################");
            _logger.LogError("##################################Error##################################");
            _logger.LogCritical("##################################Critical##################################");

            return Json("Log Successful!");
        }

    }
}
