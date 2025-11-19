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

        public Task<List<AvisoEntity>> GetAllAsync(TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default)
        {
            var query = tracking is TrackingBehavior.NoTracking ? Set.AsNoTrackingWithIdentityResolution() : Set;
            return query.Where(x => x.Ativo == true && x.DeletadoEm == null).ToListAsync();
        }

        public Task<AvisoEntity> GetByIdAsync(int id, TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default)
        {
            var query = tracking is TrackingBehavior.NoTracking ? Set.AsNoTrackingWithIdentityResolution() : Set;
            return query.Where(x => x.Id == id && x.DeletadoEm == null).FirstOrDefaultAsync();
        }

        public Task<AvisoEntity> Create(string Titulo, string Mensagem, bool Ativo, CancellationToken cancellationToken)
        {
            var entity = new AvisoEntity
            {
                Ativo = Ativo,
                Titulo = Titulo,
                Mensagem = Mensagem,
                CriadoEm = DateTime.Now,
                AtualizadoEm = DateTime.Now
            };

            var data = AddAsync(entity, cancellationToken);

            _context.SaveChangesAsync(cancellationToken);

            return data;
        }

        public AvisoEntity UpdateAsync(AvisoEntity entity, CancellationToken cancellationToken)
        {
            var data = Update(entity);

           _context.SaveChangesAsync(cancellationToken);

            return data;
        }

        public AvisoEntity DeleteAsync(AvisoEntity entity, CancellationToken cancellationToken)
        {
            entity.Delete();

            var data = Update(entity);

           _context.SaveChangesAsync(cancellationToken);

            return data;
        }
    }
}