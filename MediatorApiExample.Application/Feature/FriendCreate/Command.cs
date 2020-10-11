using MediatR;
using System;

namespace MediatorApiExample.Application.Feature.FriendCreate
{
    public partial class FriendCreate
    {
        public class Command : IRequest<Guid>
        {
            public string Name { get; }
            
            public Command(string name)
            {
                Name = name;
            }
        }
    }
}