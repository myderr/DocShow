using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocShow
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
            services.AddMvc();
            //注入
            SugarIocServices.AddSqlSugar(new IocConfig()
            {
                ConnectionString = @"DataSource=" + AppDomain.CurrentDomain.BaseDirectory + @"\database.db",
                DbType = IocDbType.Sqlite,
                IsAutoCloseConnection = true//自动释放
            });
            DbScoped.Sugar.DbMaintenance.CreateDatabase();
            //DbScoped.Sugar.CodeFirst.InitTables(typeof(Page));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Admin}/{action=Index}/{id?}");
            });
        }
    }
}
