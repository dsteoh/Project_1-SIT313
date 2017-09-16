using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Project_1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //To use navigation pages we have to wrap our page inside a NavigationPage wrapper
            MainPage = new NavigationPage(new LoginPage());
            
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
