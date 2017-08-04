using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project_1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnTopic_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TopicPage());    
        }

        async void btnSearch_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }

        async void btnProfile_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        async void btnSettings_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}

