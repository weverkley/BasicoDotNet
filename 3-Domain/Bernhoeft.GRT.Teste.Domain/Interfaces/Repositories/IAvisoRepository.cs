using Bernhoeft.GRT.Teste.Domain.Entities;
using Bernhoeft.GRT.Core.EntityFramework.Domain.Interfaces;
using Bernhoeft.GRT.Core.Enums;

namespace Bernhoeft.GRT.Teste.Domain.Interfaces.Repositories
{
    public interface IAvisoRepository : IRepository<AvisoEntity>
    {
        Task<List<AvisoEntity>> ObterTodosAvisosAsync(TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default);
        Task<AvisoEntity> ObterAvisoPorIdAsync(int id, TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default);
        Task<AvisoEntity> CadastrarAsync(string Titulo, string Mensagem, bool Ativo, CancellationToken cancellationToken);
        Task<AvisoEntity> AtualizarAsync(AvisoEntity entity, CancellationToken cancellationToken);
        Task<AvisoEntity> DeletarAsync(AvisoEntity entity, CancellationToken cancellationToken);
    }
}