using Bernhoeft.GRT.Teste.Domain.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;
using Bernhoeft.GRT.Core.Enums;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Queries.v1
{
    public class AtualizarAvisoRequestHandler : IRequestHandler<AtualizarAvisoRequest, IOperationResult<AtualizarAvisoResponse>>
    {
        private readonly IServiceProvider _serviceProvider;
        private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();

        public AtualizarAvisoRequestHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<IOperationResult<AtualizarAvisoResponse>> Handle(AtualizarAvisoRequest request, CancellationToken cancellationToken)
        {
            var entity = await _avisoRepository.ObterAvisoPorIdAsync(request.Id, TrackingBehavior.Default);
            if (entity == null)
                return OperationResult<AtualizarAvisoResponse>.ReturnNoContent();

            entity.Titulo = request.Titulo;
            entity.Mensagem = request.Mensagem;
            entity.Ativo = request.Ativo;

            await _avisoRepository.AtualizarAsync(entity, cancellationToken);

            return OperationResult<AtualizarAvisoResponse>.ReturnOk(new AtualizarAvisoResponse
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