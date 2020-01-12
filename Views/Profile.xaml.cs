using I_Like_Music.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T1809E_HelloUWP.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace I_Like_Music.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Profile : Page
    {
        private MemberService _memberService = new MemberService();
        public Profile()
        {
            this.InitializeComponent();
            this.GetMemberInformation();
        }

        public async void GetMemberInformation()
        {
            var member = await this._memberService.GetMemberInformation(Login.Token);
            if (member != null)
            {
                FirstName.Text = member.firstName;
                LastName.Text = member.lastName;
                Phone.Text = member.phone;
                Address.Text = member.address;
                Gender.Text = member.gender == 1 ? "Male" : (member.gender == 0 ? "Female" : "Other");
                Email.Text = member.email;
            }
            Avatar.Source = new BitmapImage(new Uri(member.avatar, UriKind.Absolute)); ;
        }
    }
}
