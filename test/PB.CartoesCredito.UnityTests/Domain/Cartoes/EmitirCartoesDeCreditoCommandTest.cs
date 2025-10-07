using Bogus;
using FluentAssertions;
using PB.CartoesCredito.Domain.Cartoes;
using PB.CartoesCredito.Domain.Cartoes.Command;

namespace PB.CartoesCredito.UnityTests.Domain.Cartoes
{
    public class EmitirCartoesDeCreditoCommandTest
    {
        private static readonly Faker Faker = new("pt_BR");

        [Fact(DisplayName = "Dado um comando válido, deve emitir cartoes de crédito")]
        public void Dado_um_comando_valido_deve_emitir_cartoes_de_credito()
        {
            // Arrange
            var command = new EmitirCartoesDeCreditoCommand()
            {
                ClientId = Guid.NewGuid(),
                Score = Faker.Random.Int(101, 1000),
                CreditoDisponivel = Faker.Random.Decimal(1000, 5000)
            };

            // Act
            var cartoes = CartaoDeCredito.Factory.Create(command);

            // Assert
            cartoes.Should().NotBeNull("A lista de cartões não dBeve ser nula.");
            cartoes.Count.Should().BeGreaterThan(0, "Deve haver pelo menos um cartão emitido.");

            foreach (var cartao in cartoes)
            {
                cartao.Id.Should().NotBeEmpty("O Id do cartão não foi gerado.");
                cartao.ClienteId.Should().Be(command.ClientId, "O Id do cliente no cartão não corresponde ao comando.");
                cartao.Score.Should().Be(command.Score, "O score no cartão não corresponde ao comando.");
                cartao.CreditoDisponivel.Should().Be(command.CreditoDisponivel, "O crédito disponível no cartão não corresponde ao comando.");
            }
        }

        [Fact(DisplayName = "Dado um comando com score menor ou igual a 100, não deve emitir cartoes de crédito")]
        public void Dado_um_comando_com_score_menor_ou_igual_a_100_nao_deve_emitir_cartoes_de_credito()
        {
            // Arrange
            var command = new EmitirCartoesDeCreditoCommand()
            {
                ClientId = Guid.NewGuid(),
                Score = Faker.Random.Int(0, 100),
                CreditoDisponivel = Faker.Random.Decimal(1000, 5000)
            };

            // Act
            var cartoes = CartaoDeCredito.Factory.Create(command);

            // Assert
            cartoes.Should().NotBeNull("A lista de cartões não deve ser nula.");
            cartoes.Count.Should().Be(0, "Não deve haver cartões emitidos para score menor ou igual a 100.");
        }

        [Fact(DisplayName = "Dado um comando com score entre 101 e 500, deve emitir 1 cartão de crédito")]
        public void Dado_um_comando_com_score_entre_101_e_500_deve_emitir_1_cartao_de_credito()
        {
            // Arrange
            var command = new EmitirCartoesDeCreditoCommand()
            {
                ClientId = Guid.NewGuid(),
                Score = Faker.Random.Int(101, 500),
                CreditoDisponivel = Faker.Random.Decimal(1000, 5000)
            };

            // Act
            var cartoes = CartaoDeCredito.Factory.Create(command);

            // Assert
            cartoes.Should().NotBeNull("A lista de cartões não deve ser nula.");
            cartoes.Count.Should().Be(1, "Deve haver exatamente 1 cartão emitido para score entre 101 e 500.");
        }

        [Fact(DisplayName = "Dado um comando com score maior que 500, deve emitir 2 cartões de crédito")]
        public void Dado_um_comando_com_score_maior_que_500_deve_emitir_2_cartoes_de_credito()
        {
            // Arrange
            var command = new EmitirCartoesDeCreditoCommand()
            {
                ClientId = Guid.NewGuid(),
                Score = Faker.Random.Int(501, 1000),
                CreditoDisponivel = Faker.Random.Decimal(1000, 5000)
            };

            // Act
            var cartoes = CartaoDeCredito.Factory.Create(command);

            // Assert
            cartoes.Should().NotBeNull("A lista de cartões não deve ser nula.");
            cartoes.Count.Should().Be(2, "Deve haver exatamente 2 cartões emitidos para score maior que 500.");
        }
    }
}
