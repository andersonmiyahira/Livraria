using FluentValidation;
using Livraria.Domain.Livros.Commands;
using System;

namespace Livraria.Domain.Livros.Validations
{
    public class ExcluirLivroCommandValidation : AbstractValidator<ExcluirLivroCommand>
    {
        public ExcluirLivroCommandValidation()
        {
            Validar();  
        }

        private void Validar()
        {
            RuleFor(r => r.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do livro é obrigatório");
        }
    }
}
