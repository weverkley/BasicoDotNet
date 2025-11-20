using Bernhoeft.GRT.Core.Enums;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;
using Bernhoeft.GRT.Teste.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Queries.v1
{
    public class DeletarAvisoRequestHandler : IRequestHandler<DeletarAvisoRequest, IOperationResult<DeletarAvisoResponse>>
    {
        private readonly IServiceProvider _serviceProvider;
        private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();

        public DeletarAvisoRequestHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<IOperationResult<DeletarAvisoResponse>> Handle(DeletarAvisoRequest request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
                return OperationResult<DeletarAvisoResponse>.ReturnBadRequest()
                    .AddMessage("O Id do aviso é obrigatório e deve ser maior que zero.");

            var entity = await _avisoRepository.ObterAvisoPorIdAsync(request.Id, TrackingBehavior.Default);
            if (entity == null)
                return OperationResult<DeletarAvisoResponse>.ReturnNoContent();

            await _avisoRepository.DeletarAsync(entity, cancellationToken);

            return OperationResult<DeletarAvisoResponse>.ReturnOk(new DeletarAvisoResponse
            {
                Id = entity.Id,
                Titulo = entity.Titulo,
                Ativo = entity.Ativo,
                CriadoEm = entity.CriadoEm,
                AtualizadoEm = entity.AtualizadoEm
            });
        }
    }
}