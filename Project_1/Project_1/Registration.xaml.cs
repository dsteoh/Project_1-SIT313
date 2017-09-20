using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project_1.Models;
using System.Net;
using System.Diagnostics;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Macs;

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
                byte[] shaKey = Encoding.UTF8.GetBytes("test");


                /*Password usually contain special characters.
                 * WebUtility.UrlEncode encodes the string with speical characters into Url format
                 * This allows the JSON API to read and not interfear with HTTP API commands (eg "=", " ", "&")
                */
                byte[] newPassword = Encoding.UTF8.GetBytes(password.Text);
                HmacSha256 newHash256 = new HmacSha256(newPassword);

                byte[] newHashPassword = newHash256.ComputeHash(newPassword);

                string newStringHashPassword = WebUtility.UrlEncode(BitConverter.ToString(newHashPassword));


                // WebUtility.UrlEncode

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
        }

        public class HmacSha256
        {
            private readonly HMac _hmac;

            public HmacSha256(byte[] key)
            {
                _hmac = new HMac(new Sha256Digest());
                _hmac.Init(new KeyParameter(key));
            }

            public byte[] ComputeHash(byte[] value)
            {
                if (value == null) throw new ArgumentNullException("value");

                byte[] resBuf = new byte[_hmac.GetMacSize()];
                _hmac.BlockUpdate(value, 0, value.Length);
                _hmac.DoFinal(resBuf, 0);

                return resBuf;
            }
        }
    }
}