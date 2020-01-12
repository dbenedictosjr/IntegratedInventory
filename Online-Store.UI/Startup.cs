using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Infrastructure.Mapper;
using System.Domain;
using System.Domain.Interfaces;
using System.Domain.Repositories;
using System.Infrastructure.Interfaces;
using System.Infrastructure.Services;

namespace Online_Store.UI
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
            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddEntityFrameworkSqlServer()
            .AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"],
            b => b.MigrationsAssembly("System.Domain")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Category1
            services.AddScoped<ICategory1Repository, Category1Repository>();
            services.AddScoped<ICategory1Service, Category1Service>();

            //Category2
            services.AddScoped<ICategory2Repository, Category2Repository>();
            services.AddScoped<ICategory2Service, Category2Service>();

            //Category3
            services.AddScoped<ICategory3Repository, Category3Repository>();
            services.AddScoped<ICategory3Service, Category3Service>();

            //Product
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
