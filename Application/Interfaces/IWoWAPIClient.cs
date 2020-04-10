using System.Net.Http;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWoWAPIClient
    {
        Task<HttpResponseMessage> GetCharacterAsync(string realm, string characterName);
        Task<HttpResponseMessage> GetCharacterItemsAsync(string realm, string characterName);
        Task<HttpResponseMessage> GetCharacterMythicPlusAsync(string realm, string characterName);
    }
}