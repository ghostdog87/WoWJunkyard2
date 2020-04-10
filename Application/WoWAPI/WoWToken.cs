using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Application.GlobalVariables;
using Application.Interfaces;
using Application.WoWAPI.Models;

namespace Application.WoWAPI
{
    public class WoWToken : IWoWToken
    {
        public WoWToken()
        {
        }

        public async Task<AccessToken> GetTokenAsync()
        {
            using (var client = new HttpClient())
            {
                string pass = Convert.ToBase64String(Encoding.ASCII.GetBytes(GlobalConstants.ClientId + ":" + GlobalConstants.ClientSecret));

                client.BaseAddress = new Uri("https://eu.battle.net/oauth/token");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", pass);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string res = "";

                HttpContent content = new StringContent(res, Encoding.UTF8, "application/x-www-form-urlencoded");

                var post = await client.PostAsync("?grant_type=client_credentials", content);

                string responseBody = await post.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<AccessToken>(responseBody);
            }
        }
    }
}