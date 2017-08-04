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
	public partial class ViewQuestion : ContentPage
	{
		public ViewQuestion ()
		{
			InitializeComponent ();

            ViewQuestionList.ItemsSource = new List<Question>
            {
                new Question {ImageUrl="http://lorempixel.com/100/100/people/1", Title = "Need help with ASP.NET", ForumQuestion = "Hi this is a test test test test test test test test test test test test test test test test test test test test test test test test"}
            };

		}
	}
}