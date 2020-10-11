using FluentValidation;

namespace MediatorApiExample.Application.Feature.FriendCreate
{
    public partial class FriendCreate
    {
        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(s => s.Name)
                    .NotEmpty()
                    .MinimumLength(5);
            }
        }
    }
}