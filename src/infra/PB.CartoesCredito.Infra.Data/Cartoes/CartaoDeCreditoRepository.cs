using Microsoft.EntityFrameworkCore;
using PB.CartoesCredito.Domain.Cartoes;
using PB.CartoesCredito.Domain.Cartoes.Services;
using PB.CartoesCredito.Infra.Data.Context;

namespace PB.CartoesCredito.Infra.Data.Cartoes
{
    /// <summary>
    /// Repositório de acesso a dados para entidade Cartão de Crédito, implementação concreta.
    /// </summary>
    public class CartaoDeCreditoRepository(PBCartoesCreditoDBContext context) : ICartaoDeCreditoRepository
    {
        private readonly DbSet<CartaoDeCredito> _dbSet = context.Set<CartaoDeCredito>();

        /// <summary>
        /// Persiste uma lista de cartões de crédito no banco de dados.
        /// </summary>
        /// <param name="cartoesDeCredito">Lista de cartões a serem persistidos.</param>
        /// <param name="cancellationToken">Token de cancelamento da operação.</param>
        public async Task PersistirCartoesAsync(List<CartaoDeCredito> cartoesDeCredito, CancellationToken cancellationToken)
        {
            await _dbSet.AddRangeAsync(cartoesDeCredito, cancellationToken: cancellationToken);
        }
    }
}
