using MediatorApiExample.Core.Entities;
using MediatR;

namespace MediatorApiExample.Application.Feature.GetFriendList
{
    public class GetFriendListQuery : IRequest<FriendItem[]>
    {
    }
}