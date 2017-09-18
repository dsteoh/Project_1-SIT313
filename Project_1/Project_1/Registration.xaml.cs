using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Project_1.Models;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Project_1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        private static string url = "http://introtoapps.com/datastore.php?appid=213107696";


        public Registration()
        {
            InitializeComponent();
        }

        public async void Save(string uri)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);

            //will throw an exception if not successful
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
        }



        //Navigation button
        async void btnRegister_Clicked(object sender, EventArgs e)
        {

            User testuser = User.CreateUserFromJson("{\"Username\":\"Dsteoh\", \"Password\":\"Test12345\"}");
            //await DisplayAlert("Alert", "Username" + testuser.Username + ", Password: " + testuser.Password, "OK");

            //saving
            string actualUrl = url + "&action=save&objectid=" + testuser.Username + ".user" + "&data=" + testuser.Password;
            Uri uri = new Uri(actualUrl);

            Debug.WriteLine("Running Save()");

            Save(actualUrl);

            await DisplayAlert("Alert", "Json Serialised" + testuser.ToJsonString(), "OK");

        }
    }
}