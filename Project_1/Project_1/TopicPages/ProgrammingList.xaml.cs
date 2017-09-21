using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_1.TopicPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProgrammingList : ContentPage
    {
        string Topic = "";
        private ObservableCollection<Question> _newList = new ObservableCollection<Question>();

        public ProgrammingList (Topics Name)
		{
            if(Name == null)
            {
                throw new ArgumentNullException();
            }
            BindingContext = Name;
            InitializeComponent ();
            Topic = Name.ToString();


            Debug.WriteLine("...Create List method...");
            CreateList();

            ProgramQList.ItemsSource = _newList;

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
            Debug.WriteLine("...Requesting data from our server...");
            Question[] newTopics = await FindTopics.RetrieveQuestions();

            Debug.WriteLine("...Foreach loop populating our list...");
            foreach (Question x in newTopics)
            {
                Debug.WriteLine("...Adding items to list...");
                _newList.Add(new Question { Title = x.Title.ToString() });
            }
            foreach (object x in _newList)
            {
                Debug.WriteLine(x.ToString());
            }
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
            await Navigation.PushAsync(new ViewQuestion(Topic));
            ProgramQList.SelectedItem = null; 
        }
    }
   
}