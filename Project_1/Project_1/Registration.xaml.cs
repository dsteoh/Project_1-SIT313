using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project_1.Models;

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
            Activity.IsRunning = true;
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
                byte[] shaKey = Encoding.UTF8.GetBytes("test");
                byte[] newPassword = Encoding.UTF8.GetBytes(password.Text);
                HmacSha256 newHash256 = new HmacSha256(newPassword);
                byte[] newHashPassword = newHash256.ComputeHash(newPassword);
                string newStringHashPassword = BitConverter.ToString(newHashPassword);

                //Creates a new user object and uses the data from the user and creates a JSON formatted data structure
                User NewUser = User.CreateUserFromJson("{\"Username\":\"" + newUser + "\", \"Email\":\"" + newEmail + "\", \"Password\":\"" + newStringHashPassword + "\"}");

                /* Passes NewUser object with our JSON format to the RegisterJson object 
                 * RegisterJson object contains the method Save() which contacts the server
                 */
                ServerJson userjson = new ServerJson();
                userjson.Save(NewUser);

                //Registration finished pop up
                await DisplayAlert("Alert", "User Registered" , "OK");
            }
            Activity.IsRunning = true;
        }
    }
}