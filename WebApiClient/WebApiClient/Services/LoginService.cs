using Newtonsoft.Json;
using WebApiClient.Models;

namespace WebApiClient.Services
{
    public class RespContent
    {
        public string access_token;
        public string username;
    }
    public class LoginService
    {
        HttpClient client;
        string serviceUrl;

        public LoginService()
        {
            client = new HttpClient();
            serviceUrl = @"https://localhost:7119/token?username=qwerty@gmail.com&password=55555";
        }

        public string GetToken()
        {
            var resp = client.PostAsync(serviceUrl, null).Result;
            var result = resp.Content.ReadAsStringAsync().Result;
            var token = JsonConvert.DeserializeObject<RespContent>(result);
            return token.access_token;
        }


    }
}
