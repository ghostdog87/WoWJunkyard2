using System.Collections.Generic;
using System.Threading.Tasks;
using Application.NewsApp;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class NewsController : BaseAPIController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<News>>> GetAllNews()
        {
            return await Mediator.Send(new GetAllNews.Query());
        }

        // GET: News/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await Mediator.Send(new GetNews.Query { Id = id });

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

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