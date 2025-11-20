using Bernhoeft.GRT.Teste.Domain.Entities;
using Bernhoeft.GRT.Teste.Domain.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Attributes;
using Bernhoeft.GRT.Core.EntityFramework.Infra;
using Bernhoeft.GRT.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Bernhoeft.GRT.Core.EntityFramework.Domain.Interfaces;

namespace Bernhoeft.GRT.Teste.Infra.Persistence.InMemory.Repositories
{
    [InjectService(Interface: typeof(IAvisoRepository))]
    public class AvisoRepository : Repository<AvisoEntity>, IAvisoRepository
    {
        private readonly IContext _context;

        public AvisoRepository(IServiceProvider serviceProvider, IContext context) : base(serviceProvider)
        {
            _context = context;
        }

        public Task<List<AvisoEntity>> ObterTodosAvisosAsync(TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default)
        {
            var query = tracking is TrackingBehavior.NoTracking ? Set.AsNoTrackingWithIdentityResolution() : Set;
            return query.Where(x => x.Ativo == true && x.DeletadoEm == null).ToListAsync();
        }

        public Task<AvisoEntity> ObterAvisoPorIdAsync(int id, TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default)
        {
            var query = tracking is TrackingBehavior.NoTracking ? Set.AsNoTrackingWithIdentityResolution() : Set;
            return query.Where(x => x.Id == id && x.DeletadoEm == null).FirstOrDefaultAsync();
        }

        public async Task<AvisoEntity> CadastrarAsync(string Titulo, string Mensagem, bool Ativo, CancellationToken cancellationToken)
        {
            var entity = new AvisoEntity
            {
                Ativo = Ativo,
                Titulo = Titulo,
                Mensagem = Mensagem,
                CriadoEm = DateTime.UtcNow,
                AtualizadoEm = DateTime.UtcNow
            };

            var data = await AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return data;
        }

        public async Task<AvisoEntity> AtualizarAsync(AvisoEntity entity, CancellationToken cancellationToken)
        {
            entity.AtualizadoEm = DateTime.UtcNow;

            var data = Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return data;
        }

        public async Task<AvisoEntity> DeletarAsync(AvisoEntity entity, CancellationToken cancellationToken)
        {
            entity.Delete();

            var data = Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return data;
        }
    }
}