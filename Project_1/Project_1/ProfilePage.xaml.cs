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
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Data persistence saving users Footer to app data
            if (Application.Current.Properties.ContainsKey("Footer"))
                Application.Current.Properties["Footer"] = "";
            Application.Current.Properties["Footer"] = Footer.Text;
        }
    }

}