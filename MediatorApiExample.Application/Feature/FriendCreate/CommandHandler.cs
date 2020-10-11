using System;
using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Application.Services;
using MediatorApiExample.Core.Entities;
using MediatR;

namespace MediatorApiExample.Application.Feature.FriendCreate
{
    public partial class FriendCreate
    {
        public class CommandHandler : IRequestHandler<Command, Guid>
        {
            private readonly IMediator _mediator;
            private readonly Repository _repository;

            public CommandHandler(IMediator mediator, Repository repository)
            {
                _mediator = mediator;
                _repository = repository;
            }
            
            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var friend = new FriendItem(Guid.NewGuid(), request.Name, false);

                await _repository.SaveAsync(friend);

                await _mediator.Publish(new FriendCreated(friend.Id));

                return friend.Id;
            }
        }
    }
}