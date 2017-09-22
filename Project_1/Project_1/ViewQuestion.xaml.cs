using Newtonsoft.Json;
using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        /// <summary>
        /// This class retrieve our targetted question and replies posted on the server and places them in an ObservableCollection called _newList
        /// _newList populates our ListView  ViewQuestionList
        /// </summary>
        private ObservableCollection<Question> _newList = new ObservableCollection<Question>();

        //tempStore is an object of type Question. Its purpose is to hold which topic/forum we are viewing now
        //We will use tempStore = selectedTitle
        //This will allow us to pass the current question object which contains the Question.Title string 
        //We will use this string to name the new JSON file that will store our replies for this question.
        Question tempStore = new Question();
        //This string holds the string of the users selected topic (Tittle)
        //Because we store all our data in the server under the json called userQuestions we have to find the correct one and display it's content (Question)
        string selectedTopic;

        /// <summary>
        /// Our ViewQuestion constrcutor retrives the object selectedTitle has been passed in by ProgrammingList.xaml.cs
        /// </summary>
        /// <param name="selectedTitle"></param>
        public ViewQuestion (Question selectedTitle)
		{
            if (selectedTitle == null)
            {
                throw new ArgumentNullException();
            }

            InitializeComponent ();

            CreateList();

            //We store the title of the passed in object (which is what we use to identify which json data to retrive in the json array)
            //into string selectedTopic 
            selectedTopic = selectedTitle.Title;
            
            //Assigning tempStore to be used to identify the current Question.Tittle in the Reply() page
            tempStore = selectedTitle;

            ViewQuestionList.ItemsSource = _newList;
        }
        //Properties for our New List (SHOULD BE STORE UNDER MODELS FILE)
        public ObservableCollection<Question> NewList
        {
            get
            {
                return _newList;
            }
            set
            {
                _newList = value;
            }
        }
        //CreateList method that retrives the data from the server and displays it on the ListView
        async void CreateList()
        {
            //Initialize object FindTopics
            ServerJson FindTopics = new ServerJson();
            Debug.WriteLine("...Requesting/ Storing data from our server ViewQuestions...");
            //Create an array of items type Questions from the data retrived from the server
            Question[] newTopics = await FindTopics.RetrieveQuestions();
            //Create an array of items type ReplyQuestion from the data retrived from the server
            ReplyQuestion[] newReply = await FindTopics.RetrieveReply(tempStore);

            //Identify which is the selected question title to display the right question details
            foreach (Question question in newTopics)
            {
                if (question.Title.Equals(selectedTopic))
                {
                    Debug.WriteLine("...Adding items to list ViewQuestions...");
                    _newList.Add(new Question { ForumQuestion = question.ForumQuestion.ToString() });

                }
            }
            //Identify which is the selected ReplyQuestion title to display the right ReplyQuestion details
            foreach (ReplyQuestion reply in newReply)
            {
                _newList.Add(new Question { ForumQuestion = reply.Reply.ToString() });
            }

            foreach (object x in _newList)
            {
                Debug.WriteLine(x.ToString());
            }
        }
        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Reply(tempStore));
        }
        private void ViewQuestionList_Refreshing(object sender, EventArgs e)
        {
            ViewQuestionList.ItemsSource = _newList;
        }
    }
}