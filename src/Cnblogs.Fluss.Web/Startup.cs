using System;
using System.Reflection;
using Cnblogs.Fluss.Domain;
using Cnblogs.Fluss.Domain.Entities;
using Cnblogs.Fluss.Infrastructure;
using Cnblogs.Fluss.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cnblogs.Fluss.Web
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
            services.AddMediatR(typeof(BlogSite).Assembly, typeof(Startup).Assembly);

            services.AddDbContext<BlogDbContext>(
                o =>
                {
                    o.UseSqlServer(
                        Configuration.GetConnectionString("blog"),
                        option =>
                        {
                            option.MigrationsAssembly(typeof(BlogDbContext).GetTypeInfo().Assembly.GetName().Name);
                            option.EnableRetryOnFailure(3, TimeSpan.FromSeconds(5), null);
                        });
                });
            services.AddScoped<IBlogSiteRepository, BlogSiteRepository>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BlogDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            SeedData.Seed(context);
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapDefaultControllerRoute();
                });
        }
    }
}