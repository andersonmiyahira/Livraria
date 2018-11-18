using System;

namespace Livraria.Application.AppService.Livros.ViewModels.Request
{
    public class LivroViewModelResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string ISBN { get; set; }
        public string Idioma { get; set; }
    }
}
