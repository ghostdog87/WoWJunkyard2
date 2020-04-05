using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.NewsApp
{
    public class GetNews
    {
        public class Query : IRequest<News> { 
            public int? Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, News>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<News> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.News.FindAsync(request.Id);
            }
        }
    }
}