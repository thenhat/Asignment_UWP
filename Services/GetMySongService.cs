using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using I_Like_Music.Models;
using I_Like_Music.Views;
using Newtonsoft.Json;

namespace I_Like_Music.Services
{
    public class GetMySongService
    {
        private TokenSaveFileService _tokenSaveFileService = new TokenSaveFileService();
        private string GET_MY_SONG_URL_API = "https://2-dot-backup-server-002.appspot.com/_api/v2/songs/get-mine";

        public List<Song> LoadMySongs()
        {

            Task<List<Song>> list = Task.Run(async () => await LoadMySong());
            return list.Result;
        }
        public async Task<List<Song>> LoadMySong()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Login.Token);
            var response = await httpClient.GetAsync(GET_MY_SONG_URL_API);

            var stringContent = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(stringContent);
            return JsonConvert.DeserializeObject<List<Song>>(stringContent);
        }
    }
}
