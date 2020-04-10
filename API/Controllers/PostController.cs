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

        // Delete: Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return await Mediator.Send(new Delete.Command { Id = id });
        }

        // Update: post/edit/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int? id, [FromForm] Edit.Command command)
        {
            if (id == null)
            {
                return NotFound();
            }

            command.Id = id;
            return await Mediator.Send(command);
        }
    }
}