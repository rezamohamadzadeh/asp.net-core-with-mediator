using MediatorApiExample.Application.Feature.FriendCreate;
using MediatorApiExample.Application.Feature.FriendLike;
using MediatorApiExample.Application.Feature.FriendRemove;
using MediatorApiExample.Application.Feature.GetFriendList;
using MediatorApiExample.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MediatorApiExample.Api.Controllers
{
    [ApiController]
    [Route("/api/friend")]
    public class FriendListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FriendListController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("create")]
        public async Task<Guid> CreateFriend(FriendCreate.Command cmd)
        {
            return await _mediator.Send(cmd);
        }


        [HttpPost("remove")]
        public async Task RemoveFriend(FriendRemove.Command cmd)
        {
            await _mediator.Send(cmd);
        }

        [HttpPost("like")]
        public async Task LikeFriend(FriendLikeCommand cmd)
        {
            await _mediator.Send(cmd);
        }

        [HttpGet("list")]
        public async Task<FriendItem[]> GetFriendList()
        {
            return await _mediator.Send(new GetFriendListQuery());
        }
    }
}