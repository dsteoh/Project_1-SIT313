using Newtonsoft.Json;
using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_1.TopicPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewQuestion : ContentPage
    {

        public ViewQuestion (string Topic)
		{
			InitializeComponent ();
            LoadList();

            //ViewQuestionList.ItemsSource = new List<Question>
            //{
            //    new Question {ForumQuestion = "Hi this is a test test test test test test test test test test test test test test test test test test test test test test test test"}
            //};

            async void LoadList()
            {
                string listViewQuestion ="";

                ServerJson GetQuestions = new ServerJson();
                Question[] questions = await GetQuestions.RetrieveQuestions();

                foreach (Question x in questions)
                {
                    if (x.Title == Topic)
                    {
                        listViewQuestion = x.ForumQuestion.ToString();
                    }
                }

                ViewQuestionList.ItemsSource = new List<Question>
                {
                    new Question {ForumQuestion = listViewQuestion}
                };
            }


        }
	}
}