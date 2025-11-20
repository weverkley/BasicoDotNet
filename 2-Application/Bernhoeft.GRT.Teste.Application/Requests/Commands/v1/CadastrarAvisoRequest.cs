using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1
{
    public class CadastrarAvisoRequest : IRequest<IOperationResult<CadastrarAvisoResponse>>
    {
        public bool Ativo { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
    }
}
