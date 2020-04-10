using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    public class CharacterController : BaseAPIController
    {
        private readonly DataContext _context;
        private readonly IWoWAPIClient _wowClient;


        public CharacterController(DataContext context, IWoWAPIClient wowClient)
        {
            this._context = context;
            this._wowClient = wowClient;
        }

        [HttpGet]
        public async Task<ActionResult> GetCharacterAsync(string characterName, string realm)
        {
            if (!string.IsNullOrEmpty(characterName) && (characterName.Length < 2 || characterName.Length > 12))
            {
                throw new ArgumentException("Character name must be between 2 and 12 characters!");
            }

            //TODO: replace with mongoDB client
            // var characterExistInRealm = await
            //     _context.Characters.Where(x => x.Name == characterName && x.Realm == realm).ToListAsync();

            if (characterExistInRealm.Count > 0)
            {
                var characterList = _mapper.Map<List<CharacterListViewModel>>(characterExistInRealm);

                return View(characterList);
            }

            if (realm == "Realm")
            {
                var characterExist = await
                    _context.Characters.Where(x => x.Name == characterName).ToListAsync();

                if (characterExist.Count > 0)
                {
                    var characterList = _mapper.Map<List<CharacterListViewModel>>(characterExist);

                    return View(characterList);
                }
            }

            var characterApi = await _wowClient.GetCharacterAsync(realm, characterName);

            if (characterApi.StatusCode == HttpStatusCode.NotFound)
            {
                return View(new List<CharacterListViewModel>());
            }

            using (HttpContent content = characterApi.Content)
            {
                string jsonResult = await content.ReadAsStringAsync();
                var inputModel = CharacterInputModel.FromJson(jsonResult);
                var character = _mapper.Map<Character>(inputModel);
                _context.Characters.Add(character);
                await _context.SaveChangesAsync();
            }

            var characters = _context.Characters
                .Where(x => x.Name == characterName)
                .ToList();

            var result = _mapper.Map<List<CharacterListViewModel>>(characters);
            return View(result);
        }


        
    }
}