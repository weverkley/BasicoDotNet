using Bernhoeft.GRT.Teste.Domain.Entities;
using Bernhoeft.GRT.Core.EntityFramework.Domain.Interfaces;
using Bernhoeft.GRT.Core.Enums;

namespace Bernhoeft.GRT.Teste.Domain.Interfaces.Repositories
{
    public interface IAvisoRepository : IRepository<AvisoEntity>
    {
        Task<List<AvisoEntity>> GetAllAsync(TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default);
        Task<AvisoEntity> GetByIdAsync(int id, TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default);
        Task<AvisoEntity> Create(string Titulo, string Mensagem, bool Ativo, CancellationToken cancellationToken);
        AvisoEntity UpdateAsync(AvisoEntity entity, CancellationToken cancellationToken);
        AvisoEntity DeleteAsync(AvisoEntity entity, CancellationToken cancellationToken);
    }
}