using MediatR;
using System;

namespace MediatorApiExample.Application.Feature.FriendLike
{
    public class FriendLikeCommand : IRequest
    {
        public FriendLikeCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
