using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellBeingApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WellBeingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            label_password.TextColor = Constants.TextColor;
            label_username.TextColor = Constants.TextColor;
            entry_username.TextColor = Constants.TextColor;
            entry_password.TextColor = Constants.TextColor;
            Spinner.IsVisible = false;
            LogoImage.HeightRequest = 120;

            entry_username.Completed += (s, e) => entry_password.Focus();
            entry_password.Completed += (s, e) => Register_Clicked(s, e);
        }

        async void Register_Clicked(object sender, EventArgs e)
        {
            var user = new User(entry_username.Text, entry_password.Text);
            await App.Database.CreateUserAsync(user);
            await App.Database.CreateProfileAsync(new Profile(user.Id));
        }
    }
}