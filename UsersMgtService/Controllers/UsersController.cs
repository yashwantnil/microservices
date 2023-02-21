using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UsersMgtService.Models.DTOs;

namespace UsersMgtService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var token = _generateToken(username, password);
            return Ok(token);
        }


        private static TokenDTO _generateToken(string username, string password)
        {
            var data = new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("client_id", "userMgt.client"),
                new KeyValuePair<string, string>("client_secret", "secret"),
            };

            var myHeader = "customHeader";
            using (var client = new HttpClient())
            {
                string url = "https://localhost:7126/connect/token";
                using (var httpMessage = new HttpRequestMessage())
                {
                    httpMessage.Method = HttpMethod.Post;
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", myHeader);
                    httpMessage.RequestUri = new Uri(url);
    
                    Task<HttpResponseMessage> httpResponse = client.PostAsync(url, new FormUrlEncodedContent(data));
                    using (HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                        var d = httpResponseMessage.ToString();
                        var sam = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        var result = JsonConvert.DeserializeObject<TokenDTO>(sam);
                        return result;

                    }
                }
            }
        }


    }
}
