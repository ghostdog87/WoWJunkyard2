using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Posts
{
    public class GetPost
    {
        public class Query : IRequest<Post> { 
            public int? Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Post>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Post> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Posts.FindAsync(request.Id);
            }
        }
    }
}