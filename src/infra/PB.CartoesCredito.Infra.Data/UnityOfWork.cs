using PB.Commons.Infra.Kernel.Data;
using PB.CartoesCredito.Infra.Data.Context;

namespace PB.CartoesCredito.Infra.Data
{
    public class UnityOfWork(PBCartoesCreditoDBContext context) : IUnityOfWork
    {
        private readonly PBCartoesCreditoDBContext _context = context;

        public async Task<bool> CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
