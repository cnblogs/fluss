using Cnblogs.Fluss.Domain;
using Cnblogs.Fluss.Domain.Entities;
using Cnblogs.Fluss.Infrastructure;
using Cnblogs.Fluss.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
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

            var conn = new SqliteConnection("Filename=:memory:;Foreign Keys=False");
            conn.Open();
            services.AddDbContext<BlogDbContext>(
                o =>
                {
                    o.UseSqlite(conn);
                });
            services.AddScoped<IBlogSiteRepository, BlogSiteRepository>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BlogDbContext context)
        {
            if (env.IsDevelopment())
            {
                SeedData.Seed(context);
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

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