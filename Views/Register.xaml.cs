using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using I_Like_Music.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace I_Like_Music.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        public Register()
        {
            this.InitializeComponent();
        }

        private void Create_Member(object sender, RoutedEventArgs e)
        {
            var member = new Member()
            {
                firstName = FirstName.Text,
                lastName = LastName.Text,
                password = PassWord.Password,
                address = Address.Text,
                phone = Phone.Text,
                avatar = Avatar.Text,
                gender = Convert.ToInt32(Gender.Text),
                email = Email.Text,
                //birthday = Birthday.Text
            };

            var memberJson = JsonConvert.SerializeObject(member);

            HttpContent contentToSend = new StringContent(memberJson, Encoding.UTF8, "application/json");

            SubmitData(contentToSend);
        }

        private async void SubmitData(HttpContent contentToSend)
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(
                "https://2-dot-backup-server-002.appspot.com/_api/v2/members",
                contentToSend
                );

            var stringContent = await response.Content.ReadAsStringAsync();

            var returnMember = JsonConvert.DeserializeObject<Member>(stringContent);

            Debug.WriteLine(returnMember.id);
        }

        private void Reset_Clicked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
