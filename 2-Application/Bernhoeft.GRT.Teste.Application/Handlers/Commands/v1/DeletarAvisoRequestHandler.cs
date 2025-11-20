using Bernhoeft.GRT.Teste.Domain.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Queries.v1
{
    public class DeletarAvisoRequestHandler : IRequestHandler<DeletarAvisoRequest, IOperationResult<DeletarAvisoResponse>>
    {
        private readonly IServiceProvider _serviceProvider;
        private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();

        public DeletarAvisoRequestHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<IOperationResult<DeletarAvisoResponse>> Handle(DeletarAvisoRequest request, CancellationToken cancellationToken)
        {
            var result = await _avisoRepository.CadastrarAsync(request.Titulo, request.Mensagem, request.Ativo, cancellationToken);
            if (result != null)
                return OperationResult<DeletarAvisoResponse>.ReturnNoContent();

            return OperationResult<DeletarAvisoResponse>.ReturnOk(new DeletarAvisoResponse
            {
                Id = result.Id,
                Titulo = result.Titulo,
                Ativo = result.Ativo,
                CriadoEm = result.CriadoEm,
                AtualizadoEm = result.AtualizadoEm
            });
        }
    }
}