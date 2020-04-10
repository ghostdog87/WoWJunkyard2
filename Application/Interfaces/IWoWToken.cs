using System.Threading.Tasks;
using Application.WoWAPI.Models;

namespace Application.Interfaces
{
    public interface IWoWToken
    {
         Task<AccessToken> GetTokenAsync();
    }
}