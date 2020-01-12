using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using I_Like_Music.Models;
using System.Net;
using I_Like_Music.Services;

namespace I_Like_Music.Services
{
    class AuthenticationService
    {
        private static string CONTENT_TYPE = "application/json";
        private static string LOGIN_API_URL = "https://2-dot-backup-server-002.appspot.com/_api/v2/members/authentication";

        public async Task<string> LoginTask(string email, string password)
        {
            JObject loginInfo = new JObject();
            loginInfo["email"] = email;
            loginInfo["password"] = password;
            var loginJson = JsonConvert.SerializeObject(loginInfo);
            HttpContent contentToSend = new StringContent(loginJson,
                Encoding.UTF8, CONTENT_TYPE);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync(LOGIN_API_URL, contentToSend);
            var stringContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.Created)
            {
                var token = (string)JObject.Parse(stringContent)["token"];
                await FileHandleService.WriteToFile("token.txt", token);
                return token;
            }

            return null;
        }
    }
}
