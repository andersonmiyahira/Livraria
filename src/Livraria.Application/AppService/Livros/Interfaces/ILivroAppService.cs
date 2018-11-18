using Livraria.Application.AppService.Livros.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Application.AppService.Livros.Interfaces
{
    public interface ILivroAppService : IDisposable
    {
        void Salvar(LivroViewModelRequest livro);
        IEnumerable<LivroViewModelResponse> ObterTodos();
        LivroViewModelResponse ObterPorId(Guid id);
        void Atualizar(LivroViewModelRequest livro);
        void Excluir(Guid id);
    }
}
