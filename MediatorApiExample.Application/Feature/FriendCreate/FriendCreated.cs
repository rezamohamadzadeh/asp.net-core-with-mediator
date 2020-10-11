using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorApiExample.Application.Feature.FriendCreate
{
    public class FriendCreated : INotification
    {
        public FriendCreated(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class EmailSend : INotificationHandler<FriendCreated>
    {
        public Task Handle(FriendCreated notification, CancellationToken cancellationToken)
        {
            // send email

            return Task.CompletedTask;
        }
    }

    public class SmsSend : INotificationHandler<FriendCreated>
    {
        public Task Handle(FriendCreated notification, CancellationToken cancellationToken)
        {
            // send sms

            return Task.CompletedTask;
        }
    }
}
