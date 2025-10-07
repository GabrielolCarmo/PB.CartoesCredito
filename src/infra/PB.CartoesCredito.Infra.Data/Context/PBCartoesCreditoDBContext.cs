using Microsoft.EntityFrameworkCore;
using PB.CartoesCredito.Infra.Data.Context.Mapping;

namespace PB.CartoesCredito.Infra.Data.Context
{
    public class PBCartoesCreditoDBContext(DbContextOptions<PBCartoesCreditoDBContext> opt) : DbContext(opt)
    {
        public readonly DbContextOptions<PBCartoesCreditoDBContext> _opt = opt;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CartaoDeCreditoMap());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
