using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PB.CartoesCredito.Domain.Cartoes.Services;
using PB.CartoesCredito.Infra.Data.Cartoes;
using PB.CartoesCredito.Infra.Data.Context;
using PB.Commons.Infra.Kernel.Data;

namespace PB.CartoesCredito.Infra.Data
{
    public static class ServicesExtensions
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<ICartaoDeCreditoRepository, CartaoDeCreditoRepository>();

            services.AddDbContext<PBCartoesCreditoDBContext>((provider, opt) =>
            {
                opt.UseInMemoryDatabase("memorydatabase");
            });
        }
    }
}