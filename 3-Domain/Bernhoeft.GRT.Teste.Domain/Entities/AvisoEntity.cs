using Bernhoeft.GRT.Teste.Domain.Base;

namespace Bernhoeft.GRT.Teste.Domain.Entities
{
    public partial class AvisoEntity : BaseAuditableEntity, ISoftDelete
    {
        public int Id { get; private set; }
        public bool Ativo { get; set; } = true;
        public string Titulo { get; set; }
        public string Mensagem { get; set; }

        public DateTime? DeletadoEm { get; set; }

        public void Delete()
        {
            Ativo = false;
            DeletadoEm = DateTime.UtcNow;
        }

        public void UndoDelete()
        {
            Ativo = true;
            DeletadoEm = null;
        }
    }
}