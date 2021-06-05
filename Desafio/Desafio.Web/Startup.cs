using Autofac;
using Autofac.Extensions.DependencyInjection;
using Desafio.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SDK.DependencyInjection;
using SDK.DependencyInjection.AutoFac;
using SDK.DependencyInjection.Interfaces;

namespace Desafio.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ILifetimeScope AutofacContainer { get; private set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Conection

            services.AddEntityFrameworkSqlServer()
                   .AddDbContext<DesafioContext>(
                       options => options.UseSqlServer(
                           Configuration.GetConnectionString("DesafioConnectionString")));
         
            #endregion          

            services.AddControllersWithViews();
        }

        public void ConfigureContainer(ContainerBuilder builder) // chamado pelo autofac
        {
            var sdkContainerBuilder = new AutofacContainerBuilder(builder);

            sdkContainerBuilder.RegisterScoped<ISdkContainer>(c => new AutofacContainer(this.AutofacContainer));

            Application.DependencyInjection.RegisterDependencies(sdkContainerBuilder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            SdkDI.SetGlobalResolver(this.AutofacContainer.Resolve<ISdkContainer>());

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
