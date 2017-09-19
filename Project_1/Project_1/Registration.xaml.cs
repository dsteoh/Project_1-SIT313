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
        //Server URL that we are going to store our JSON data to
        private static string url = "http://introtoapps.com/datastore.php?appid=213107696";


        public Registration()
        {
            InitializeComponent();
        }

        //Navigation button
        async void btnRegister_Clicked(object sender, EventArgs e)
        {
            //Initialising........Storing text/data from the Entry fields
            string newEmail = email.Text;
            string newUser = username.Text;

            /*Password usually contain special characters.
             * WebUtility.UrlEncode encodes the string with speical characters into Url format
             * This allows the JSON API to read and not interfear with HTTP API commands (eg "=", " ", "&")
            */
            string newPassword = WebUtility.UrlEncode(password.Text);

            //Creates a new user object and uses the data from the user and creates a JSON formatted data structure
            User NewUser = User.CreateUserFromJson("{\"Username\":\""+ newUser + "\", \"Email\":\"" + newEmail + "\", \"Password\":\"" + newPassword + "\"}");

            /* Tjis string "actualUrl" Attaches the API commands that we need to talk to the server with our JSON file
             * objectid identifies which JSON object are we targeting 
             * .user is the prefix we use to identify our users
             * data= is the JSON data we are about to send to the server
             * 
             * We wrap our data in [] to create an array
            */
            string actualUrl = url + "&action=append&objectid=" + NewUser.Username + ".user" + "&data=[" + NewUser.ToJsonString() + "]";

            Uri uri = new Uri(actualUrl);
        
            /* RegisterJson object contains the method Save() which contacts the server
             * And passes our JSON data to the server
             */
            RegisterJson userjson = new RegisterJson();
            userjson.Save(uri);

            //Registration finished pop up
            await DisplayAlert("Alert", "User Registered" + actualUrl, "OK");

        }
    }
}