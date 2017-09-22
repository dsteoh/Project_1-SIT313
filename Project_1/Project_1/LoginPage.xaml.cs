using PCLStorage;
using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            
            if(Application.Current.Properties.ContainsKey("Username"))
                username.Text = Application.Current.Properties["Username"].ToString();
        }
        /// <summary>
        /// This method handles when the users press the login button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void btnLogin_Clicked(object sender, EventArgs e)
        {
            //Acitvity indicator
            Activity.IsRunning = true;
            ServerJson checkUser = new ServerJson();
            //Checking for empty fields
            Debug.WriteLine("Check for Empty fields");    
            if(String.IsNullOrWhiteSpace(username.Text) || (String.IsNullOrWhiteSpace(password.Text)))
            {
                await DisplayAlert("Oops", "Please fill in the fields", "OK");
            }
            else
            {
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

                //Check if user password and username match Method is called in ServerJson.cs
                Debug.WriteLine("Check true of false for matching username and password");
                bool result = await checkUser.CheckUserPasswordAsync(username.Text, newStringHashPassword);
  
                if (result == true)
                {
                    //If result is true we log the user in and store it's username in data
                    Application.Current.Properties["LoggedInUser"] = username.Text;
                    await Application.Current.SavePropertiesAsync();
                    //Push user to mainpage after login
                    await Navigation.PushModalAsync(new MainPage());
                }
                if (result == false)
                {
                    await DisplayAlert("Oops", "Invalid Login Credentials", "Ok"); 
                }
            }
            Activity.IsRunning = false;
        }

        async void btnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Registration());
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            //remember user if switch is toggled using data persistence
            if (Application.Current.Properties.ContainsKey("Username"))
                Application.Current.Properties["Username"] = "";

            Application.Current.Properties["Username"] = username.Text;

        }
    }
}