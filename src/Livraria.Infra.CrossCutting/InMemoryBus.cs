﻿using Livraria.Domain.Core.Bus;
using Livraria.Domain.Core.Commands;
using Livraria.Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace Livraria.CrossCutting
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }
    }
}
