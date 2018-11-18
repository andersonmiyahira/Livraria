using FluentValidation;
using Livraria.Domain.Livros.Commands;

namespace Livraria.Domain.Livros.Validations
{
    public class AdicionarLivroCommandValidation : AbstractValidator<AdicionarLivroCommand>
    {
        public AdicionarLivroCommandValidation()
        {
            Validar();
        }

        private void Validar()
        {
            RuleFor(r => r.Titulo)
                .NotEmpty().WithMessage("Título é obrigatório")
                .Length(3, 100).WithMessage("Título deve ter entre 3 e 100 caracteres");

            RuleFor(r => r.Descricao)
                .NotEmpty().WithMessage("Descrição é obrigatório")
                .Length(3, 255).WithMessage("Descrição deve ter entre 3 e 255 caracteres");

            RuleFor(r => r.Autor)
               .NotEmpty().WithMessage("Autor é obrigatório")
               .Length(3, 100).WithMessage("Autor deve ter entre 3 e 100 caracteres");

            RuleFor(r => r.Editora)
               .NotEmpty().WithMessage("Editora é obrigatório")
               .Length(3, 100).WithMessage("Editora deve ter entre 3 e 100 caracteres");

            RuleFor(r => r.ISBN)
               .NotEmpty().WithMessage("ISBN é obrigatório")
               .Length(3, 50).WithMessage("ISBN deve ter entre 3 e 100 caracteres");
        } 
    }
}
