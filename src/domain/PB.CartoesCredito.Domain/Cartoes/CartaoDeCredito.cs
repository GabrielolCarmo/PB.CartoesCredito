using PB.CartoesCredito.Domain.Cartoes.Command;
using PB.Commons.Infra.Kernel.Domain;

namespace PB.CartoesCredito.Domain.Cartoes
{
    /// <summary>
    /// Representa uma proposta de crédito, agregando regras de negócio para análise e liberação de crédito.
    /// A motivação desta classe é centralizar a lógica de decisão e persistência de propostas, garantindo integridade e coesão.
    /// </summary>
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

        /// <summary>
        /// Classe Factory para criação controlada de cartões de crédito,
        /// incorporando regras de negócio relacionadas à emissão de cartões.
        /// </summary>
        public static class Factory
        {
            /// <summary>
            /// Cria uma lista de cartões de crédito de acordo com o comando recebido.
            /// </summary>
            /// <param name="command">Comando de emissão de cartões.</param>
            /// <returns>Lista de cartões de crédito emitidos.</returns>
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

            /// <summary>
            /// Obtém a quantidade de cartões a serem liberados conforme o score.
            /// </summary>
            /// <param name="score">Score do cliente.</param>
            /// <returns>Quantidade de cartões a serem emitidos.</returns>
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

            /// <summary>
            /// Verifica se o score permite a liberação de cartão.
            /// </summary>
            /// <param name="score">Score do cliente.</param>
            /// <returns>Permite se for maior que 100.</returns>
            private static bool ScorePermiteLiberacaoDeCartao(int score)
            {
                return score > 100;
            }
        }
    }
}
