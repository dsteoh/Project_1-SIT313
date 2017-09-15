using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project_1
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.Children.Add(new TopicPage());
            this.Children.Add(new SearchPage());
            this.Children.Add(new ProfilePage());
            this.Children.Add(new SettingsPage());

        }

        ////Navigation buttons
        //async void btnTopic_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new TopicPage());    
        //}

        //async void btnSearch_Click(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new SearchPage());
        //}

        //async void btnProfile_Click(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new ProfilePage());
        //}

        //async void btnSettings_Click(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new SettingsPage());
        //}
    }
}

