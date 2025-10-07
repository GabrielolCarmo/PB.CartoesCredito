using MassTransit;
using PB.CartoesCredito.Domain.Cartoes.Command;
using PB.Commons.Api.Models;
using PB.Commons.Infra.Kernel.Data;

namespace PB.CartoesCredito.Api.Consumers
{
    public class CartaoDeCreditoConsumer(MediatR.IMediator mediator, IUnityOfWork uow) : IConsumer<CreditoDisponibilizadoMessage>
    {
        private readonly MediatR.IMediator _mediator = mediator;
        private readonly IUnityOfWork _uow = uow;

        public async Task Consume(ConsumeContext<CreditoDisponibilizadoMessage> context)
        {
            var message = context.Message;
            var command = new EmitirCartoesDeCreditoCommand
            {
                ClientId = message.ClienteId,
                Score = message.Score,
                CreditoDisponivel = message.CreditoDisponivel
            };

            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                await _uow.CommitTransactionAsync();
            }
        }
    }
}
