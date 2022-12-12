using Newtonsoft.Json;

namespace MauiAppClient.Services
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
            
            
            serviceUrl = Preferences.Get("apiUrl","") +
                @"token?username=qwerty@gmail.com&password=55555";
        }

        public string GetToken()
        {
            if (App.Current.Resources.ContainsKey("Token"))
                return App.Current.Resources["Token"].ToString();

            var resp = client.PostAsync(serviceUrl, null).Result;
            var result = resp.Content.ReadAsStringAsync().Result;
            var token = JsonConvert.DeserializeObject<RespContent>(result);
            App.Current.Resources["Token"] = token.access_token;
            return token.access_token;
        }


    }
}
