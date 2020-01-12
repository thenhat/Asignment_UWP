using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using I_Like_Music.Models;
using I_Like_Music.Views;

namespace I_Like_Music.Services
{
    class GetListSongService
    {
        private string GET_LIST_SONG_URL_API = "https://2-dot-backup-server-002.appspot.com/_api/v2/songs";
        private TokenSaveFileService _tokenSaveFileService = new TokenSaveFileService();

        public List<Song> LoadSongs()
        {

            Task<List<Song>> list = Task.Run(async () => await LoadSong());
            return list.Result;
        }

        public async Task<List<Song>> LoadSong()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Login.Token);
            var response = await httpClient.GetAsync(GET_LIST_SONG_URL_API);
            
            var stringContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Song>>(stringContent);
        }
    }
}
