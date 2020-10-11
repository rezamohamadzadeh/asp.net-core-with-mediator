using System;
using MediatR;

namespace MediatorApiExample.Application.Feature.FriendRemove
{
    public partial class FriendRemove
    {
        public class Command : IRequest
        {
            public Guid Id { get; }

            public Command(Guid id)
            {
                Id = id;
            }
        }
    }
}