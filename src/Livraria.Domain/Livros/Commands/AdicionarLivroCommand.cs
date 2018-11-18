using Livraria.Domain.Livros.Validations;

namespace Livraria.Domain.Livros.Commands
{
    public class AdicionarLivroCommand : LivroCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new AdicionarLivroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
