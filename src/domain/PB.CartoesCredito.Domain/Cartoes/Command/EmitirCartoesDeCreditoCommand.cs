using MediatR;
using PB.Commons.Infra.Kernel.Application;

namespace PB.CartoesCredito.Domain.Cartoes.Command
{
    /// <summary>
    /// Comando para emitir cartões de crédito para um cliente.
    /// </summary>
    public class EmitirCartoesDeCreditoCommand : IRequest<IServiceOperationResult>
    {
        public Guid ClientId { get; set; }

        public int Score { get; set; }

        public decimal CreditoDisponivel { get; set; }
    }
}
