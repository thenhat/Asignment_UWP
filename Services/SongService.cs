using I_Like_Music.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace I_Like_Music.Services
{
    class SongService
    {
        private static readonly string SongInformationApiUrl = "https://2-dot-backup-server-002.appspot.com/_api/v2/songs/";
        public async Task<ObservableCollection<Song>> GetSongInformation(string token)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var response = await httpClient.GetAsync(SongInformationApiUrl);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stringContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ObservableCollection<Song>>(stringContent);
            }
            return null;
        }
    }
}
