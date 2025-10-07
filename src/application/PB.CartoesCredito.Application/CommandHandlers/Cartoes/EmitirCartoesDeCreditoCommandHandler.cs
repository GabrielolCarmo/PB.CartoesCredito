using MediatR;
using PB.CartoesCredito.Domain.Cartoes;
using PB.CartoesCredito.Domain.Cartoes.Command;
using PB.CartoesCredito.Domain.Cartoes.Services;
using PB.Commons.Infra.Kernel.Application;

namespace PB.CartoesCredito.Application.CommandHandlers.Cartoes
{
    public class EmitirCartoesDeCreditoCommandHandler(ICartaoDeCreditoRepository repository) : IRequestHandler<EmitirCartoesDeCreditoCommand, IServiceOperationResult>
    {
        private readonly ICartaoDeCreditoRepository _repository = repository;

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
