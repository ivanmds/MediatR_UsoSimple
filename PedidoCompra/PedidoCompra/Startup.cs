using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PedidoCompra.Contextos;
using PedidoCompra.Domain.PedidoAggregate.Commands;
using PedidoCompra.Domain.PedidoAggregate.Handlers;
using PedidoCompra.Domain.PedidoAggregate.Interfaces.Repositorios;
using PedidoCompra.Repositorios;
using System.Reflection;
using FluentValidation.Results;
using PedidoCompra.Domain.PedidoAggregate.Notifications;

namespace PedidoCompra
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddMediatR(typeof(IMediator).GetTypeInfo().Assembly);
            
            services.AddScoped(typeof(Contexto));
            services.AddScoped<IRequestHandler<PedidoAddCommand, ValidationResult>, PedidoHandler>();
            services.AddScoped<IRequestHandler<PedidoDeletarCommand, ValidationResult>, PedidoHandler>();
            services.AddScoped<INotificationHandler<PedidoAddNotification>, AvisarFinanceiroNotificarion>();
            services.AddScoped<INotificationHandler<PedidoAddNotification>, EnviarEmailNotificarion>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPedidoQueryRepository, PedidoQueryRepository>();

            services.AddTransient<IPedidoCommandRepository, PedidoCommandRepository>();
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
