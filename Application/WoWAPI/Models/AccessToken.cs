using System.Text.Json.Serialization;

namespace Application.WoWAPI.Models
{
    public class AccessToken
    {
        [JsonPropertyName("access_token")]
        public string AccessTokenKey { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public string ExpiresIn { get; set; }
    }
}