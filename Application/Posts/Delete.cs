using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Posts
{
    public class Delete
    {
        public class Command : IRequest { 
            public int? Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.FindAsync(command.Id);

                _context.Posts.Remove(post);

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                {
                    return Unit.Value;
                }

                throw new Exception("Post could not be deleted!");
            }
        }
    }
}