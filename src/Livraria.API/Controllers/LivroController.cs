using Livraria.Application.AppService.Livros.Interfaces;
using Livraria.Application.AppService.Livros.ViewModels.Request;
using Livraria.Domain.Core.Bus;
using Livraria.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Livraria.API.Controllers
{
    public class LivroController : ApiController
    {
        private readonly ILivroAppService _livroService;

        public LivroController(INotificationHandler<DomainNotification> notifications, 
                                  IMediatorHandler mediator,
                                  ILivroAppService livroAppService) 
            : base(notifications, mediator)
        {
            _livroService = livroAppService;
        }

        [HttpGet]
        [Route("livro")]
        public IActionResult Get()
        {
            return Response(_livroService.ObterTodos());
        }

        [HttpGet]
        [Route("livro/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var livro = _livroService.ObterPorId(id);
            return Response(livro);
        }

        [HttpPost]
        [Route("livro")]
        public IActionResult Post([FromBody]LivroViewModelRequest request)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }

            _livroService.Salvar(request);
            return Response(request);
        }

        [HttpPut]
        [Route("livro")]
        public IActionResult Put([FromBody]LivroViewModelRequest request)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }

            _livroService.Atualizar(request);
            return Response(request);
        }

        [HttpDelete]
        [Route("livro/{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            _livroService.Excluir(id);
            return Response();
        }
    }
}
