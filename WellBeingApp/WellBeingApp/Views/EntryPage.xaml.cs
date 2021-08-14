using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WellBeingApp.Models;

namespace WellBeingApp.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        public EntryPage()
        {
            InitializeComponent();
        }

        async void Submit_Clicked(object sender, EventArgs e)
        {
            var userEntry = (UserEntry)BindingContext;
            userEntry.Score = (userEntry.Sleeping + userEntry.Eatting + userEntry.Activity + userEntry.Emotional) / 4;
            userEntry.Date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(userEntry);
            await Navigation.PopAsync();
        }
    }
}