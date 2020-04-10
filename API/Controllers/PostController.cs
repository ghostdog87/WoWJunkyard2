using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Posts;
using Application.Posts.ResourceModels;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PostController : BaseAPIController
    {
        // GET: Posts/
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<AllPosts>>> GetAllPosts()
        {
            return await Mediator.Send(new GetAll.Query());
        }

        // GET: Posts/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await Mediator.Send(new GetPost.Query { Id = id });

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        // POST: Posts/
        [HttpPost]
        public async Task<ActionResult<Unit>> Create([FromForm] Create.Command command)
        {
            if(command.Image == null){
                return NotFound();
            }
            return await Mediator.Send(command);
        }
    }
}