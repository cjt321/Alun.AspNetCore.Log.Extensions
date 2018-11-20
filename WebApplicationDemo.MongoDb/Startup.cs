using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alun.AspNetCore.Log.Extensions.Configuration;
using Alun.AspNetCore.Log.Extensions.Log;
using Alun.AspNetCore.Log.Extensions.MongoDb.Ex;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplicationDemo.MongoDb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //log start 添加mongodb的配置
            services.AddLogging(cfg =>
            {
                cfg.AddNvLog(
                        new LogConfiguration() { UseTraceLog = false, UseDebugLog = true,
                            UseInformationLog = true, UseErrorLog = true, UseCriticalLog = true })
                    .AddMongoDbLog("mongodb://xxx:xxx@xxx:27017", "MyLog");

            });
            //log end

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
