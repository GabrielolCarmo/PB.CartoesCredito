using MediatR;
using PB.CartoesCredito.Domain.Cartoes;
using PB.CartoesCredito.Domain.Cartoes.Command;
using PB.CartoesCredito.Domain.Cartoes.Services;
using PB.Commons.Infra.Kernel.Application;

namespace PB.CartoesCredito.Application.CommandHandlers.Cartoes
{
    /// <summary>
    /// Handler do comando para gerar uma lista de cartões de crédito, realiza a orquestração entre os serviços de domínio.
    /// </summary>
    public class EmitirCartoesDeCreditoCommandHandler(ICartaoDeCreditoRepository repository) : IRequestHandler<EmitirCartoesDeCreditoCommand, IServiceOperationResult>
    {
        private readonly ICartaoDeCreditoRepository _repository = repository;

        /// <summary>
        /// Orquestra o processo de criação des multiplos cartões de crédito de acordo com o dominio.
        /// </summary>
        /// <param name="request">Comando de emissão de cartões.</param>
        /// <param name="cancellationToken">Token de cancelamento da operação.</param>
        /// <returns>Resultado da operação de serviço.</returns>
        public async Task<IServiceOperationResult> Handle(EmitirCartoesDeCreditoCommand request, CancellationToken cancellationToken)
        {
            var result = new ServiceOperationResult();
            var cartoes = CartaoDeCredito.Factory.Create(request);
            if (cartoes.Count == 0)
            {
                return result;
            }

            await _repository.PersistirCartoesAsync(cartoes, cancellationToken);
            return result;
        }
    }
}
