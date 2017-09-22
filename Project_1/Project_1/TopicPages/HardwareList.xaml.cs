using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_1.TopicPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HardwareList : ContentPage
	{
		public HardwareList (Topics Name)
		{
            if (Name == null)
            {
                throw new ArgumentNullException();
            }
            BindingContext = Name;

            InitializeComponent ();

            //Populate the ListView HardwareQlist. It uses the object ListProperties
            HardwareQList.ItemsSource = new List<ListProperties>
            {
                new ListProperties {Title= "Best CPU?", Description = "Posted on the 24th"},
                new ListProperties {Title= "How to overclock?", Description = "Posted Today"},
            };
        }
        //A button to add to the forum.
    }
}