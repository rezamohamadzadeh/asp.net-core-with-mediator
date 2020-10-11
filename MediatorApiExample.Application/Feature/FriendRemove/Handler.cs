using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Application.Services;
using MediatorApiExample.Core.Entities;
using MediatR;

namespace MediatorApiExample.Application.Feature.FriendRemove
{
    public partial class FriendRemove
    {
        public class Handler : IRequestHandler<Command>
        {
            private readonly Repository _repository;

            public Handler(Repository repository)
            {
                _repository = repository;
            }
            
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _repository.RemoveAsync<FriendItem>(request.Id);
                
                return Unit.Value;
            }
        }
    }
}