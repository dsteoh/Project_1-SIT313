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

        async void btnLogin_Clicked(object sender, EventArgs e)
        {
            Activity.IsRunning = true;
            ServerJson checkUser = new ServerJson();

            Debug.WriteLine("Check for Empty fields");    
            if(String.IsNullOrWhiteSpace(username.Text) || (String.IsNullOrWhiteSpace(password.Text)))
            {
                await DisplayAlert("Oops", "Please fill in the fields", "OK");
            }
            else
            {
                byte[] shaKey = Encoding.UTF8.GetBytes("test");
                byte[] newPassword = Encoding.UTF8.GetBytes(password.Text);
                HmacSha256 newHash256 = new HmacSha256(newPassword);
                byte[] newHashPassword = newHash256.ComputeHash(newPassword);
                string newStringHashPassword = BitConverter.ToString(newHashPassword);


                Debug.WriteLine("Check true of false for matching username and password");
                bool result = await checkUser.CheckUserPasswordAsync(username.Text, newStringHashPassword);
  
                if (result == true)
                {
                    Application.Current.Properties["Username"] = username.Text;
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
            Application.Current.Properties["Username"] = username.Text;

            // Application.Current.SavePropertiesAsync(); <--- stores data as in real time good for email typing etc
        }  
    }
}