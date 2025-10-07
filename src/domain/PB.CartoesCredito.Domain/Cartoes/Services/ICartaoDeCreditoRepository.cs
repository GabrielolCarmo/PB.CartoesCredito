
namespace PB.CartoesCredito.Domain.Cartoes.Services
{
    /// <summary>
    /// Interface para repositório de cartões de crédito, as interfaces de repositório ficam na camada de dominio pois nada mais são do que serviços de dominio.
    /// </summary>
    public interface ICartaoDeCreditoRepository
    {
        /// <summary>
        /// Persiste uma lista de cartões de crédito no repositório.
        /// </summary>
        /// <param name="cartoesDeCredito">Lista de cartões a serem persistidos.</param>
        /// <param name="cancellationToken">Token de cancelamento da operação.</param>
        public Task PersistirCartoesAsync(List<CartaoDeCredito> cartoesDeCredito, CancellationToken cancellationToken);
    }
}
