using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellBeingApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WellBeingApp.Views;

namespace WellBeingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
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
            LogoImage.HeightRequest = Constants.LogoHeight;

            entry_username.Completed += (s, e) => entry_password.Focus();
            entry_password.Completed += (s, e) => SignIn_Clicked(s, e);
        }


        async void SignIn_Clicked (object sender, EventArgs e)
        {
            try
            {
                User user = await App.Database.GetUserAsync(entry_username.Text);
                if (entry_password.Text == user.Password)
                {
                    Profile profile = await App.Database.GetProfileAsync(user.Id);
                    await Navigation.PushAsync(new ProfilePage
                    {
                        BindingContext = profile 
                    });
                }
                else
                {
                    DisplayAlert("Login", "Invalid Password", "OK");
                }
            }
            catch (Exception)
            {
                DisplayAlert("Login", "User Not Found", "OK");
            }

        }

        async void Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}