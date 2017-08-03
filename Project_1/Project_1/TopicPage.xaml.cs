using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Project_1.TopicPages.Programming;

namespace Project_1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TopicPage : ContentPage
	{
		public TopicPage ()
		{
			InitializeComponent ();

            TopicList.ItemsSource = new List<Topics>
            {
                new Topics {Name = "Programming"},
                new Topics {Name = "Hardware"},
                new Topics {Name = "Software"},
                new Topics {Name = "Cryptocurrency"},
                new Topics {Name = "Gaming"}

            };
		}

        async void TopicList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }

    
            var TopicName = e.SelectedItem as Topics;
            if (TopicName.Name == "Programming")
            {
                await Navigation.PushAsync(new ProgrammingList(TopicName));
            }
            TopicList.SelectedItem = null;
        }
    }
}