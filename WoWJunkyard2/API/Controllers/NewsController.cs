using System.Collections.Generic;
using System.Threading.Tasks;
using Application.NewsApp;
using Domain;
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
    }
}