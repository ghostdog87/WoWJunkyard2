using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Application.GlobalVariables;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Application.Posts
{
    public class Edit
    {
        public class Command : IRequest
        {
            public int? Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public IFormFile Image { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly UserManager<WoWUser> _userManager;

            public Handler(DataContext context, UserManager<WoWUser> userManager)
            {
                _userManager = userManager;
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                string mediaRootPath = GlobalConstants.MediaRootFolder;

                var uploads = Path.Combine(mediaRootPath, @"img\news");
                var extension = Path.GetExtension(request.Image.FileName);

                var randomName = Path.GetRandomFileName(); // TODO: might need unique key in future

                using (var filesStream = new FileStream(Path.Combine(uploads, randomName + extension), FileMode.Create))
                {
                    request.Image.CopyTo(filesStream);
                }

                var post = await _context.Posts.FindAsync(request.Id);

                post.Title = request.Title;
                post.Description = request.Description;
                post.Image = @"news/" + randomName + extension;

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                {
                    return Unit.Value;
                }

                throw new Exception("Problem updating changes.");
            }
        }
    }
}