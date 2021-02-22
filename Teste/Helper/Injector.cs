using Data;
using Data.Entities;
using Data.Interface;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Teste
{
    public class Injector
    {
        public static void SetInjections(IServiceCollection services)
        {
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<ICarrinhoService, CarrinhoService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
