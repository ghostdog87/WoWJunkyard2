using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Application
{
    public class Login
    {
        public class Query : IRequest<WoWUser>
        {
            public string Email { get; set; }
            public string Password { get; set; }

        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, WoWUser>
        {
            private readonly UserManager<WoWUser> _userManager;
            private readonly SignInManager<WoWUser> _signInManager;

            public Handler(UserManager<WoWUser> userManager, SignInManager<WoWUser> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }
            public async Task<WoWUser> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);

                if (user == null)
                {
                    throw new RestException(HttpStatusCode.Unauthorized);
                }
                
                var result = await _signInManager.CheckPasswordSignInAsync(user,request.Password,false);

                if (result.Succeeded)
                {
                    //TODO: pass token
                    return user;
                }

                throw new RestException(HttpStatusCode.Unauthorized);
            }
        }
    }
}
