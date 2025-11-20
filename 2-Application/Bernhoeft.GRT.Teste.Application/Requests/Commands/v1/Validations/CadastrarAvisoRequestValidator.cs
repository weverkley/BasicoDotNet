using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations
{
    public class CadastrarAvisoRequestValidator : AbstractValidator<CadastrarAvisoRequest>
    {
        public CadastrarAvisoRequestValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O Título é obrigatório.");


            RuleFor(x => x.Mensagem)
                .NotEmpty().WithMessage("A Mensagem é obrigatória.");
        }
    }
}
