using Project_1.Models;
using System;
using System.Collections.Generic;
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
                email.Text = Application.Current.Properties["Email"].ToString();

            if (Application.Current.Properties.ContainsKey("Password"))
                password.Text = Application.Current.Properties["Password"].ToString();
        }

        async void btnLogin_Clicked(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(email.Text) || (String.IsNullOrWhiteSpace(email.Text)))
            {
                await DisplayAlert("Oops", "Please fill in the fields", "OK");
            }
            else
            {
                
            }


            await Navigation.PushModalAsync(new MainPage());
        }

        async void btnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Registration());
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            Application.Current.Properties["Email"] = email.Text;
            Application.Current.Properties["Password"] = password.Text;

            // Application.Current.SavePropertiesAsync(); <--- stores data as in real time good for email typing etc
        }  
    }
}