using Livraria.Domain.Livros.Validations;
using System;

namespace Livraria.Domain.Livros.Commands
{
    public class ExcluirLivroCommand : LivroCommand
    {
        public ExcluirLivroCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new ExcluirLivroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
