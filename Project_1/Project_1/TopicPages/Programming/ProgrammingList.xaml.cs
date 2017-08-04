using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_1.TopicPages.Programming
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProgrammingList : ContentPage
	{
		public ProgrammingList (Topics Name)
		{
            if(Name == null)
            {
                throw new ArgumentNullException();
            }
            BindingContext = Name;

			InitializeComponent ();

            //Populates the ListView
            ProgramQList.ItemsSource = new List<ListProperties>
            {
                new ListProperties {Title= "Need help with ASP.NET", Description = "Posted on the 24th"},
                new ListProperties {Title= "What are objects?", Description = "Posted Today"},
                new ListProperties {Title= "Where to download Xamarin?", Description = "Posted on the 30th"},
                new ListProperties {Title= "test", Description = "test"},
                new ListProperties {Title= "test", Description = "test"}

            };
		}

        //Button (To add a new forum thread
        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            DisplayAlert("Add Option", "Add A new Thread", "ok");
        }

        async void ProgramQList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }

            //Deselect listview item after being selected
            await Navigation.PushAsync(new ViewQuestion());

            ProgramQList.SelectedItem = null; 
        } 
    }
}