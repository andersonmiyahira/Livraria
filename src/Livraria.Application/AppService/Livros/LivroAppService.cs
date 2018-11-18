using AutoMapper;
using AutoMapper.QueryableExtensions;
using Livraria.Application.AppService.Livros.Interfaces;
using Livraria.Application.AppService.Livros.ViewModels.Request;
using Livraria.Domain.Core.Bus;
using Livraria.Domain.Livros.Commands;
using Livraria.Domain.Livros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Livraria.Application.AppService.Livros
{
    public class LivroAppService : ILivroAppService
    {
        private readonly IMapper _mapper;
        private readonly ILivroRepository _livroRepository;
        private readonly IMediatorHandler _bus;

        public LivroAppService(IMapper mapper,
                               ILivroRepository livroRepository,
                               IMediatorHandler bus)
        {
            _mapper = mapper;
            _livroRepository = livroRepository;
            _bus = bus;
        }

        public IEnumerable<LivroViewModelResponse> ObterTodos()
        {
            return _livroRepository
                               .GetAll()
                               .OrderBy(_ => _.Autor)
                               .ProjectTo<LivroViewModelResponse>();
        }

        public LivroViewModelResponse ObterPorId(Guid id)
        {
            var livro = _mapper.Map<LivroViewModelResponse>(_livroRepository.GetById(id));
            return livro;
        }

        public void Excluir(Guid id)
        {
            var excluirLivroCommand = new ExcluirLivroCommand(id);
            _bus.SendCommand(excluirLivroCommand);
        }

        public void Salvar(LivroViewModelRequest livro)
        {
            var adicionarLivroCommand = _mapper.Map<AdicionarLivroCommand>(livro);
            _bus.SendCommand(adicionarLivroCommand);
        }

        public void Atualizar(LivroViewModelRequest livro)
        {
            var atualizarLivroCommand = _mapper.Map<AtualizarLivroCommand>(livro);
            _bus.SendCommand(atualizarLivroCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
