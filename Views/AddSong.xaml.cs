using I_Like_Music.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace I_Like_Music.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddSong : Page
    {
        public AddSong()
        {
            this.InitializeComponent();
        }

        private void Create_Song(object sender, RoutedEventArgs e)
        {
            var song = new Song()
            {
                name = SongName.Text,
                description = Description.Text,
                singer = Singer.Text,
                author = Author.Text,
                thumbnail = Thumbnail.Text,
                link = Link.Text
            };

            var songJson = JsonConvert.SerializeObject(song);

            HttpContent contentToSend = new StringContent(songJson, Encoding.UTF8, "application/json");

            SubmitData(contentToSend);
        }

        private async void SubmitData(HttpContent contentToSend)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + Login.Token);
            var response = await httpClient.PostAsync(
                "https://2-dot-backup-server-002.appspot.com/_api/v2/songs",
                contentToSend
                );

            var stringContent = await response.Content.ReadAsStringAsync();

            var returnSong = JsonConvert.DeserializeObject<Song>(stringContent);

            Debug.WriteLine(returnSong.id);
        }

        private void Reset_Clicked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
