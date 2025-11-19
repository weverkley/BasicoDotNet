namespace Bernhoeft.GRT.Teste.Domain.Base
{
     public abstract class BaseAuditableEntity
    {
        public DateTime CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}