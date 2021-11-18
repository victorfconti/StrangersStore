using System.Threading.Tasks;
using MediatR;
using NerdStore.core.Messages;

namespace NerdStore.core
{
    public class MediatRHandler : IMediatrHandler
    {
        private readonly IMediator _mediator;

        public MediatRHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }
    }
}