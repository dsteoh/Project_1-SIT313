using Project_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_1.TopicPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewQuestion : ContentPage
    {
        public NewQuestion()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            string Title = title.Text;
            string ForumQuestion = questionEdit.Text;
            string Desc = description.Text;

            Debug.WriteLine("Starting new object newq");
            //Creates a NewQuestion object and uses the data from the user and creates a JSON formatted data structure
            Question NewQuestion = Question.CreateQuestionFromJson("{\"Title\":\"" + Title + "\", \"ForumQuestion\":\"" + ForumQuestion + "\", \"Description\":\"" + Desc + "\"}");

            /* Passes QuestionJson object with our JSON format to the RegisterJson object 
             * RegisterJson object contains the method Save() which contacts the server
             */
            ServerJson QuestionJson = new ServerJson();
            Debug.WriteLine("sending newq to severjson");
            QuestionJson.NewQuestion(NewQuestion);

            await DisplayAlert("Alert", NewQuestion.ToJsonString(), "OK");

        }
    }
}