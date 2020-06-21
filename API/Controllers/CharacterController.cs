using System.Net.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Microsoft.AspNetCore.Authorization;
using Application.Errors;
using MediatR;
using Application.Character;

namespace API.Controllers
{
    public class CharacterController : BaseAPIController
    {
        private readonly IMediator _mediator;
        public CharacterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: Character/
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> GetCharacter([FromForm] SearchCharacter.Query query)
        {
            return await _mediator.Send(query);
        }
    }
}