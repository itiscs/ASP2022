using Newtonsoft.Json;
using MauiApp1.Models;
using Java.Util;

namespace MauiApp1.Services
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
            
            serviceUrl = 
                @"http://localhost:8081/token?username=qwerty@gmail.com&password=55555";
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
