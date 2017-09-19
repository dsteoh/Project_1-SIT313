using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project_1.Models;
using System.Net;
using System.Diagnostics;
using Org.BouncyCastle.Crypto.Digests;
namespace Project_1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {

        public Registration()
        {
            InitializeComponent();

        }

        //Navigation button
        async void btnRegister_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(email.Text) && String.IsNullOrEmpty(username.Text) && String.IsNullOrEmpty(password.Text))
            {
                await DisplayAlert("Oops", "Please fill in the fields", "OK");
            }
            else if (email.TextColor == Color.Red)
            {
                await DisplayAlert("Oops", "Invalid Email address", "OK");
            }
            else
            {
                //Initialising........Storing text/data from the Entry fields
                string newEmail = email.Text;
                string newUser = username.Text;



                /*Password usually contain special characters.
                 * WebUtility.UrlEncode encodes the string with speical characters into Url format
                 * This allows the JSON API to read and not interfear with HTTP API commands (eg "=", " ", "&")
                */
                string newPassword =  WebUtility.UrlEncode(password.Text);

                //Creates a new user object and uses the data from the user and creates a JSON formatted data structure
                User NewUser = User.CreateUserFromJson("{\"Username\":\"" + newUser + "\", \"Email\":\"" + newEmail + "\", \"Password\":\"" + newPassword + "\"}");

                /* Passes NewUser object with our JSON format to the RegisterJson object 
                 * RegisterJson object contains the method Save() which contacts the server
                 */
                RegisterJson userjson = new RegisterJson();
                userjson.Save(NewUser);

                //Registration finished pop up
                await DisplayAlert("Alert", "User Registered" , "OK");
            }
        }
    }
}