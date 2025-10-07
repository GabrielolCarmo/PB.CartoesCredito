namespace PB.CartoesCredito.Domain.Cartoes.Command
{
    public class EmitirCartoesDeCreditoCommand
    {
        public Guid ClientId { get; set; }

        public int Score { get; set; }

        public decimal CreditoDisponivel { get; set; }
    }
}
