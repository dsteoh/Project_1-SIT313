using Project_1.Models;
using Project_1.Models.ProgrammingList;
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

            ProgramQList.ItemsSource = new List<ProgrammingListProperties>
            {
                new ProgrammingListProperties {Title= "Need help with ASP.NET", Description = "Posted on the 24th"},
                new ProgrammingListProperties {Title= "What are objects?", Description = "Posted Today"},
                new ProgrammingListProperties {Title= "Where to download Xamarin?", Description = "Posted on the 30th"},
                new ProgrammingListProperties {Title= "test", Description = "test"},
                new ProgrammingListProperties {Title= "test", Description = "test"}

            };

		}

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            DisplayAlert("Activated", "Toolactivate", "ok");
        }
    }
}