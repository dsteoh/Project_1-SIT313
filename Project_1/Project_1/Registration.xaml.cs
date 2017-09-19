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

        //Navigation button
        async void btnRegister_Clicked(object sender, EventArgs e)
        {
            string newUsername = username.ToString();
            string passwordTest = password.ToString();
            string newPassword = WebUtility.UrlEncode(password.ToString());

            Debug.WriteLine(newPassword);

            User testuser = User.CreateUserFromJson("{\"Username\":\"testNewUser1\", \"Password\":\""+newPassword+"\"}");
            //await DisplayAlert("Alert", "Username" + testuser.Username + ", Password: " + testuser.Password, "OK");      
            //await DisplayAlert("Alert", "Json Serialised" + testuser.ToJsonString(), "OK");
            Debug.WriteLine(testuser.Password);

            //saving
            string actualUrl = url + "&action=save&objectid=" + testuser.Username + ".user" + "&data=" + testuser.Password;

            Debug.WriteLine("Running Save()");
        
            RegisterJson userjson = new RegisterJson();
            userjson.Save(actualUrl);

            await DisplayAlert("Alert", "User Registered" + testuser.ToJsonString(), "OK");

        }
    }
}