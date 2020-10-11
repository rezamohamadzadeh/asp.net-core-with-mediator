using MediatorApiExample.Application;
using MediatorApiExample.Application.Feature.FriendCreate;
using MediatorApiExample.Application.Feature.FriendLike;
using MediatorApiExample.Application.Feature.GetFriendList;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class FullFlowTests
    {
        private readonly IMediator _mediator;

        public FullFlowTests()
        {
            var services = new ServiceCollection();

            services.AddApplication(s =>
            {
                s.MongoConnection = "mongodb://localhost:32768/admin";
                s.MongoDatabaseName = "FriendList-Test";
            });

            var provider = services.BuildServiceProvider();

            _mediator = provider.GetRequiredService<IMediator>();
        }


        [Fact]
        public async Task Create_And_Get()
        {
            var names = Enumerable.Range(0, 3)
                .Select(s => Path.GetFileName(Path.GetTempFileName()))
                .ToArray();

            foreach (var name in names)
            {
                await _mediator.Send(new FriendCreate.Command(name));
            }

            var list = await _mediator.Send(new GetFriendListQuery());

            foreach (var name in names)
            {
                Assert.Contains(name, list.Select(s => s.Name));
            }
        }

        [Fact]
        public async Task Create_And_Like_And_Dislike()
        {
            var name = Path.GetFileName(Path.GetTempFileName());
            var id = await _mediator.Send(new FriendCreate.Command(name));

            for (int i = 0; i < 3; i++)
            {
                await _mediator.Send(new FriendLikeCommand(id));
                var isLiked = i % 2 == 0;

                var list = await _mediator.Send(new GetFriendListQuery());
                var item = list.First(s => s.Id == id);

                Assert.Equal(isLiked, item.Liked);
            }
        }
    }
}
