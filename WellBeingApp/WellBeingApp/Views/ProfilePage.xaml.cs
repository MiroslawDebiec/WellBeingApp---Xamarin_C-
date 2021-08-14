using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;
using Microcharts;
using SkiaSharp;
using System.ComponentModel;
using WellBeingApp.Models;

namespace WellBeingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class ProfilePage : ContentPage
    {
        List<UserEntry> userEntries = new List<UserEntry>();
        List<Entry> entries = new List<Entry>();


        public ProfilePage()
        {
            InitializeComponent();
            var profile = (Profile)BindingContext;
            getUser(profile);
            //ProfileChart.Chart = new LineChart
            //{
            //    Entries = entries,
            //    LineSize = 10,
            //    LineAreaAlpha = 50,
            //    Margin = 40,
            //    LabelTextSize = 40,
            //    LineMode = LineMode.Spline,
            //    PointMode = PointMode.Circle,
            //    PointSize = 15,
            //    BackgroundColor = SKColor.Parse("#0080FF"),
               
            //};
        }

        async void getUser(Profile profile)
        {
            var username = await App.Database.GetUserAsync(profile.UserId);
            username_label.Text = "Welcome " + username;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            userEntries = userEntries = await App.Database.GetNotesAsync();
            listView.ItemsSource = userEntries;
            //addToChart(userEntries);
        }

        async void AddClicked(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            await Navigation.PushAsync(new EntryPage
            {
                BindingContext = new UserEntry()
            });
            //addToChart(userEntries);
        }

        //private List<Entry> addToChart(List<UserEntry> userEntries)
        //{

        //    entries.Clear();

        //    for (int i = 0; i < 5; i++)
        //    {
        //        Entry entry = new Entry(userEntries.ElementAt(userEntries.Count - 1 - i).Score)
        //        {
        //            Color = SKColor.Parse("#EBEBEB"),
        //            TextColor = SKColor.Parse("#EBEBEB"),
        //            ValueLabel = userEntries.ElementAt(userEntries.Count - 1 - i).Score.ToString(),
        //            Label = (userEntries.ElementAt(userEntries.Count - 1 - i).Date.Day.ToString() + "/" + userEntries.ElementAt(userEntries.Count - 1 - i).Date.Month.ToString())
        //        };
        //        entries.Add(entry);
        //    }
        //    entries.Reverse();
        //    return entries;
        //}
    }
}