using System;
using FluentValidation;

namespace MediatorApiExample.Application.Feature.FriendRemove
{
    public partial class FriendRemove
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(s => s.Id).Must((id) => id != Guid.Empty);
            }
        }
    }
}