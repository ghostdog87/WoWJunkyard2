using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Application.Posts.ResourceModels;

namespace Application.Posts
{
    public class GetAll
    {
        public class Query : IRequest<List<AllPosts>> { }

        public class Handler : IRequestHandler<Query, List<AllPosts>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<AllPosts>> Handle(Query request, CancellationToken cancellationToken)
            {
                var posts = await _context.Posts.ToListAsync();

                var result = posts
                .Select(x => new AllPosts()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    PostedOn = x.PostedOn,
                    Image = x.Image,
                    DisplayName = _context.Users.FindAsync(x.UserId).Result.DisplayName
                }).ToList();
                
                return result;
            }
        }
    }
}