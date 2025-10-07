
namespace PB.CartoesCredito.Domain.Cartoes.Services
{
    public interface ICartaoDeCreditoRepository
    {
        public Task PersistirCartoesAsync(List<CartaoDeCredito> cartoesDeCredito, CancellationToken cancellationToken);
    }
}
