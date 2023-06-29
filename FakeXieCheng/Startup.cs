using FakeXieCheng.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FakeXieCheng.Services;

namespace FakeXieCheng
{
    public class Startup
    {

        //public IConfiguration Configuration { get; }

        //protected Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages();
            //services.AddMvc();
            services.AddControllers();

            services.AddDbContext<AppDbContext>();

            services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //IApplicationBuilder创建中间件
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
