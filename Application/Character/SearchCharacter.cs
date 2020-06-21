using System.Net.Http;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using MediatR;

namespace Application.Character
{
    public class SearchCharacter
    {
        public class Query : IRequest<string>
        {
            public string characterName { get; set; }
            public string realmName { get; set; }
        }

        public class Handler : IRequestHandler<Query, string>
        {
            private readonly IWoWAPIClient _wowClient;
            public Handler(IWoWAPIClient wowClient)
            {
                _wowClient = wowClient;
            }
            public async Task<string> Handle(Query request, CancellationToken cancellationToken)
            {
                if (!string.IsNullOrEmpty(request.characterName) && (request.characterName.Length < 2 || request.characterName.Length > 12))
                {
                    throw new RestException(HttpStatusCode.BadRequest, new { Character = "Character name must be between 2 and 12 characters!" });
                }

                //TODO: save API calls with mongoDB client

                var characterApi = await _wowClient.GetCharacterAsync(request.realmName, request.characterName);

                if (characterApi.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new RestException(HttpStatusCode.BadRequest, new { Character = "Character was not found!" });
                }

                string jsonResult = string.Empty;

                using (HttpContent content = characterApi.Content)
                {
                    jsonResult = await content.ReadAsStringAsync();
                }

                return jsonResult;
            }
        }
    }
}