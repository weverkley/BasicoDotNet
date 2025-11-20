using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations
{
    public class AtualizarAvisoRequestValidator : AbstractValidator<AtualizarAvisoRequest>
    {
        public AtualizarAvisoRequestValidator()
        {
            RuleFor(x => x.Mensagem)
                .NotEmpty().WithMessage("A Mensagem é obrigatória.");
        }
    }
}
