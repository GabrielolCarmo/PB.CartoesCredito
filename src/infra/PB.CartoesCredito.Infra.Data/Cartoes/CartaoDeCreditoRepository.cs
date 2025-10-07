using Microsoft.EntityFrameworkCore;
using PB.CartoesCredito.Domain.Cartoes;
using PB.CartoesCredito.Domain.Cartoes.Services;
using PB.CartoesCredito.Infra.Data.Context;

namespace PB.CartoesCredito.Infra.Data.Cartoes
{
    public class CartaoDeCreditoRepository(PBCartoesCreditoDBContext context) : ICartaoDeCreditoRepository
    {
        private readonly DbSet<CartaoDeCredito> _dbSet = context.Set<CartaoDeCredito>();

        public async Task PersistirCartoesAsync(List<CartaoDeCredito> cartoesDeCredito, CancellationToken cancellationToken)
        {
            await _dbSet.AddRangeAsync(cartoesDeCredito, cancellationToken: cancellationToken);
        }
    }
}
