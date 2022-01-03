using CNPJ.App.AppServices;
using CNPJ.App.AutoMapper;
using CNPJ.App.Interfaces;
using CNPJ.Domain.Interfaces;
using CNPJ.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CNPJ.Data.Context;
using Microsoft.EntityFrameworkCore;
using CNPJ.Data.Repositories;

namespace CNPJ.IU
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
            services.AddScoped<IConsultAppService, ConsultAppService>();
            services.AddScoped<ISearchCnpjWsAPIService, SearchCnpjWsAPIService>();
            services.AddScoped<IAddDbService, AddDbService>();
            services.AddScoped<IConsultCnpjRepository, ConsultCnpjRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapperSetup();

            var cs = 
            services.AddDbContext<ConsultCnpjDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConsultCnpjDb")
                , b => b.MigrationsAssembly("CNPJ.Data")));
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
