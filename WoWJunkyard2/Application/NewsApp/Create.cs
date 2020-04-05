using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Application.GlobalVariables;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace Application.NewsApp
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public IFormFile Image { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
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
                
                var news = new News()
                {
                    Title = request.Title,
                    Description = request.Description,
                    PostedOn = new DateTime(),
                    Image = @"news/" + randomName + extension,
                };

                _context.News.Add(news);
                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                {
                    return Unit.Value;
                }

                throw new Exception("Problem saving changes.");
            }
        }
    }
}