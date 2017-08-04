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
	public partial class SearchPage : ContentPage
	{
		public SearchPage ()
		{
			InitializeComponent ();
            SearchList.ItemsSource = GetLists();
		}

        IEnumerable<ListProperties>GetLists(string searchText = null)
        {
            var lists = new List<ListProperties> {
            new ListProperties {Title= "Need help with ASP.NET", Description = "Posted on the 24th"},
            new ListProperties {Title= "What are objects?", Description = "Posted Today"},
            new ListProperties {Title= "Where to download Xamarin?", Description = "Posted on the 30th"}
            };
                if (string.IsNullOrWhiteSpace(searchText))
                    return lists;

            return lists.Where(c => c.Title.StartsWith(searchText));
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchList.ItemsSource = GetLists(e.NewTextValue);
        }
    }
}