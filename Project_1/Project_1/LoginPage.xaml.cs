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
            
            if(Application.Current.Properties.ContainsKey("Email"))
                username.Text = Application.Current.Properties["Email"].ToString();

            if (Application.Current.Properties.ContainsKey("Password"))
                password.Text = Application.Current.Properties["Password"].ToString();
        }

        async void btnLogin_Clicked(object sender, EventArgs e)
        {
            byte[] shaKey = Encoding.UTF8.GetBytes("test");
            byte[] newPassword = Encoding.UTF8.GetBytes(password.Text);
            HmacSha256 newHash256 = new HmacSha256(newPassword);
            byte[] newHashPassword = newHash256.ComputeHash(newPassword);
            string newStringHashPassword = BitConverter.ToString(newHashPassword);

            Debug.WriteLine("Check for Empty fields");    
            if(String.IsNullOrWhiteSpace(username.Text) || (String.IsNullOrWhiteSpace(password.Text)))
            {
                await DisplayAlert("Oops", "Please fill in the fields", "OK");
            }
            else
            {
                Debug.WriteLine("Starting json server connection...");
                ServerJson checkUser = new ServerJson();

                Debug.WriteLine("Check true of false for matching username and password");
                checkUser.CheckUserPasswordAsync(username.Text, newStringHashPassword);
               
            }
        }

        async void btnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Registration());
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            Application.Current.Properties["Email"] = username.Text;
            Application.Current.Properties["Password"] = password.Text;

            // Application.Current.SavePropertiesAsync(); <--- stores data as in real time good for email typing etc
        }  
    }
}