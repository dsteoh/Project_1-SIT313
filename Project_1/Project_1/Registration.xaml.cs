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
    public partial class Registration : ContentPage
    {
        
        public Registration()
        {
            InitializeComponent();
        }
        //Navigation button
        async void btnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());

        }
    }
}