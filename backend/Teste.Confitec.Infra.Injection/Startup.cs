using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teste.Confitec.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Teste.Confitec.Domain.Confitec.Usuario.Interfaces;
using Teste.Confitec.Domain.Confitec.Usuario.Services;
using Teste.Confitec.Infra.Data.Repository;
using Teste.Confitec.Infra.Injection.AutoMapper;
using AutoMapper;
using Teste.Confitec.Domain.Interfaces;

namespace Teste.Confitec.Infra.Injection
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //// ASP.NET HttpContext dependency
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<ConfitecDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:Confitec"],
                x => x.MigrationsHistoryTable("__ConfitecHistory")
                ));

            ConfigureGenericsServices(services, configuration);

            services.AddAutoMapper();

            AutoMapperConfiguration.Initialize();
        }

        private static void ConfigureGenericsServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));
            services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            services.AddScoped(typeof(IArmazenadorDeUsuario), typeof(ArmazenadorDeUsuario));
            services.AddScoped(typeof(IExclusorDeUsuario), typeof(ExclusorDeUsuario));
        }
    }
}
