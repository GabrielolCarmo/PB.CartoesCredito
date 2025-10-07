using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PB.CartoesCredito.Domain.Cartoes;

namespace PB.CartoesCredito.Infra.Data.Context.Mapping
{
    public class CartaoDeCreditoMap : IEntityTypeConfiguration<CartaoDeCredito>
    {
        public void Configure(EntityTypeBuilder<CartaoDeCredito> builder)
        {
            builder.ToTable(nameof(CartaoDeCredito));
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(p => p.ClienteId)
                .HasColumnName("ClienteId")
                .IsRequired();

            builder.Property(p => p.Score)
                .HasColumnName("Score")
                .IsRequired();

            builder.Property(p => p.CreditoDisponivel)
                .HasColumnName("CreditoDisponivel")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Ignore(x => x.Events);
        }
    }
}
