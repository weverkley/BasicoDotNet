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
    public class AtualizarAvisoRequestHandler : IRequestHandler<AtualizarAvisoRequest, IOperationResult<AtualizarAvisoResponse>>
    {
        private readonly IServiceProvider _serviceProvider;
        private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();

        public AtualizarAvisoRequestHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<IOperationResult<AtualizarAvisoResponse>> Handle(AtualizarAvisoRequest request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
                return OperationResult<AtualizarAvisoResponse>.ReturnBadRequest()
                    .AddMessage("O Id do aviso é obrigatório e deve ser maior que zero.");

            var entity = await _avisoRepository.ObterAvisoPorIdAsync(request.Id, TrackingBehavior.Default);
            if (entity == null)
                return OperationResult<AtualizarAvisoResponse>.ReturnNoContent();

            entity.Mensagem = request.Mensagem;

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