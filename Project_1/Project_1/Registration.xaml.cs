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
        /// <summary>
        /// This method handles when the user press the Register button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void btnRegister_Clicked(object sender, EventArgs e)
        {
            Activity.IsRunning = true;
            //We check if fields are entered properly
            if (String.IsNullOrEmpty(email.Text) && String.IsNullOrEmpty(username.Text) && String.IsNullOrEmpty(password.Text))
            {
                await DisplayAlert("Oops", "Please fill in the fields", "OK");
            }
            //We are using EmailValidatorBehavior to check if the email entered is correct using Regex [changes to red when wrong]
            //Display Alert if email is wrong
            else if (email.TextColor == Color.Red)
            {
                await DisplayAlert("Oops", "Invalid Email address", "OK");
            }
            else
            {
                //Initialising........Storing text/data from the Entry fields
                string newEmail = email.Text;
                string newUser = username.Text;         
                
                //Initailizing data to begin our HmacSHA256 encryption on the password
                //Our private key
                byte[] shaKey = Encoding.UTF8.GetBytes("test");
                //Encode password....
                //We first have to convert password to byte format
                byte[] newPassword = Encoding.UTF8.GetBytes(password.Text);
                //Encode password to sha256
                HmacSha256 newHash256 = new HmacSha256(newPassword);
                byte[] newHashPassword = newHash256.ComputeHash(newPassword);
                //Read our password as a string this allows us to add it to our JSON file
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
                await Navigation.PushModalAsync(new LoginPage());

            }
            Activity.IsRunning = false;
        }
    }
}