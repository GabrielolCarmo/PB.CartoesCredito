using PB.CartoesCredito.Domain.Cartoes.Command;
using PB.Commons.Infra.Kernel.Domain;

namespace PB.CartoesCredito.Domain.Cartoes
{
    public class CartaoDeCredito : AggregateRoot
    {
        private CartaoDeCredito(Guid id, Guid clienteId, int score, decimal creditoDisponivel) : base(id)
        {
            ClienteId = clienteId;
            Score = score;
            CreditoDisponivel = creditoDisponivel;
        }

        public Guid ClienteId { get; private set; }

        public int Score { get; private set; }

        public decimal CreditoDisponivel { get; private set; }

        public static class Factory
        {
            public static List<CartaoDeCredito> Create(EmitirCartoesDeCreditoCommand command)
            {
                var cartoes = new List<CartaoDeCredito>();
                var quantidadesDeCartoesLiberados = ObterQuantidadeDeCartoesPorScore(command.Score);

                for (int i = 0; i < quantidadesDeCartoesLiberados; i++)
                {
                    cartoes.Add(new CartaoDeCredito(
                        Guid.NewGuid(),
                        command.ClientId,
                        command.Score,
                        command.CreditoDisponivel
                    ));
                }

                return cartoes;
            }

            private static int ObterQuantidadeDeCartoesPorScore(int score)
            {
                if (!ScorePermiteLiberacaoDeCartao(score))
                {
                    return 0;
                }

                if (score <= 500)
                {
                    return 1;
                }

                return 2;
            }

            private static bool ScorePermiteLiberacaoDeCartao(int score)
            {
                return score > 100;
            }
        }
    }
}
