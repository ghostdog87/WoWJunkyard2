using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.NewsApp
{
    public class GetAllNews
    {
        public class Query : IRequest<List<News>> { }

        public class Handler : IRequestHandler<Query, List<News>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<News>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.News.ToListAsync();
            }
        }
    }
}