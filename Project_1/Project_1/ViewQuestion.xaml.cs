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
        private ObservableCollection<Question> _newList = new ObservableCollection<Question>();

        string selectedTopic;

        public ViewQuestion (Question selectedTitle)
		{
            if (selectedTitle == null)
            {
                throw new ArgumentNullException();
            }

            InitializeComponent ();
            CreateList();
            selectedTopic = selectedTitle.Title;
            Debug.WriteLine("THIS IS THE SELECTED TOPIC AFTER" + selectedTopic);

            ViewQuestionList.ItemsSource = _newList;
        }
        public ObservableCollection<Question> NewList
        {
            get
            {
                return _newList;
            }
            set
            {
                _newList = value;
                //NotifyPropertyChanged("NewList");
            }
        }

        async void CreateList()
        {
            ServerJson FindTopics = new ServerJson();
            Debug.WriteLine("...Requesting data from our server ViewQuestions...");
            Question[] newTopics = await FindTopics.RetrieveQuestions();

            Debug.WriteLine("...Foreach loop populating our list ViewQuestions...");

            Debug.WriteLine("THIS IS THE SELECTED TOPIC BEFORE FOREACH"+selectedTopic);

            foreach (Question x in newTopics)
            {
                Debug.WriteLine("THIS IS THE SELECTED TOPIC INSIDE FOREACH" + selectedTopic);
                if (x.Title.Equals(selectedTopic))
                {
                    Debug.WriteLine("...Adding items to list ViewQuestions...");
                    _newList.Add(new Question { ForumQuestion = x.ForumQuestion.ToString() });
                }
            }

            foreach (object x in _newList)
            {
                Debug.WriteLine(x.ToString());
            }
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {

        }
    }
}