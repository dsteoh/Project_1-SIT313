using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project_1.TopicPages.Programming;
using Project_1.TopicPages.Hardware;

namespace Project_1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TopicPage : ContentPage
	{
		public TopicPage ()
		{
			InitializeComponent ();

            //This populates the ListView with the Topics available
            TopicList.ItemsSource = new List<Topics>
            {
                new Topics {Name = "Programming"},
                new Topics {Name = "Hardware"},
                new Topics {Name = "Software"},
                new Topics {Name = "Cryptocurrency"},
                new Topics {Name = "Gaming"}

            };
		}
        
        //This method handles the Items in the ListView when selected
        async void TopicList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }

            //TopicName stores the selected item
            var TopicName = e.SelectedItem as Topics;

            //if statement to identify which topic the user seelected and bring them to the approiate page
            if (TopicName.Name == "Programming")
            {
                await Navigation.PushAsync(new ProgrammingList(TopicName));
            }

            if (TopicName.Name == "Hardware")
            {
                await Navigation.PushAsync(new HardwareList(TopicName));
            }

            TopicList.SelectedItem = null;
        }
    }
}