using I_Like_Music.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using T1809E_HelloUWP.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace I_Like_Music.Views
{
    public sealed partial class Login : Page
    {
        private Dictionary<string, string> _errorMsgDictionary = new Dictionary<string, string>();
        private AuthenticationService _service = new AuthenticationService();
        public static string Token;

        public Login()
        {
            this.InitializeComponent();
        }

        private async void Login_Clicked(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Email.Text))
            {
                EmailErrorMsg.Text = "Please Insert Email!";
            }

            if (String.IsNullOrEmpty(PassWord.Password))
            {
                PasswordErrorMsg.Text = "Please Insert Password!";
            }
            var email = Email.Text;
            var password = PassWord.Password;

            Token = await this._service.LoginTask(email, password);
            if (Token != null)
            {
                await GetToken();
                this.Frame.Navigate(typeof(Views.Profile));
            }
        }

        public static async Task<string> GetToken()
        {
            var result = await FileHandleService.ReadFile("token.txt");
            Token = result;
            return result;
        }

        private void Reset_Clicked(object sender, RoutedEventArgs e)
        {
            Email.Text = "";
            PassWord.Password = "";
            EmailErrorMsg.Text = "";
            PasswordErrorMsg.Text = "";
        }
    }
}
