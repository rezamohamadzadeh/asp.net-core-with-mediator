using MediatorApiExample.Application.Services;
using MediatorApiExample.Core.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorApiExample.Application.Feature.FriendLike
{
    public class FriendLikeCommandHandler : IRequestHandler<FriendLikeCommand>
    {
        private readonly Repository _repository;

        public FriendLikeCommandHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(FriendLikeCommand request, CancellationToken cancellationToken)
        {
            var item = await _repository.FindByIdAsync<FriendItem>(request.Id);
            if (item == null) throw new ApplicationException("Friend not found");

            item.ToggleLike();

            await _repository.SaveAsync(item);

            return Unit.Value;
        }
    }
}
