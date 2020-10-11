using System.Threading;
using System.Threading.Tasks;
using MediatorApiExample.Application.Services;
using MediatorApiExample.Core.Entities;
using MediatR;

namespace MediatorApiExample.Application.Feature.GetFriendList
{
    public class GetFriendListQueryHandler : IRequestHandler<GetFriendListQuery, FriendItem[]>
    {
        private readonly Repository _repository;

        public GetFriendListQueryHandler(Repository repository)
        {
            _repository = repository;
        }

        public async Task<FriendItem[]> Handle(GetFriendListQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.FindAsync<FriendItem>();

            return items.ToArray();
        }
    }
}