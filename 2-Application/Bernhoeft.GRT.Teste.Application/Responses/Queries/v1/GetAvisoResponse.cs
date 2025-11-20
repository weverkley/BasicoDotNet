using Bernhoeft.GRT.Teste.Domain.Entities;

namespace Bernhoeft.GRT.Teste.Application.Responses.Queries.v1
{
    public class GetAvisoResponse
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public string Titulo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }

        public static implicit operator GetAvisoResponse(AvisoEntity entity) => new()
        {
            Id = entity.Id,
            Ativo = entity.Ativo,
            Titulo = entity.Titulo,
            CriadoEm = entity.CriadoEm,
            AtualizadoEm = entity.AtualizadoEm
        };
    }
}