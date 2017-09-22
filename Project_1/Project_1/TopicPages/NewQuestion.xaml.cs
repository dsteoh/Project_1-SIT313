using Project_1.Models;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_1.TopicPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewQuestion : ContentPage
    {
        //string footer;

        public NewQuestion()
        {
            //footer = Application.Current.Properties["Footer"].ToString();
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            string Title = title.Text;
            string ForumQuestion = questionEdit.Text;
            string Desc = description.Text;
            //Creates a NewQuestion object and uses the data from the user and creates a JSON formatted data structure
            Question NewQuestion = Question.CreateQuestionFromJson("{\"Title\":\"" + Title + "\", \"ForumQuestion\":\"" + ForumQuestion + "\", \"Description\":\"" + Desc + "\"}");

            /* Passes QuestionJson object with our JSON format to the RegisterJson object 
             * RegisterJson object contains the method Save() which contacts the server
             */
            ServerJson QuestionJson = new ServerJson();
            QuestionJson.NewQuestion(NewQuestion);
            await DisplayAlert("Alert", "New Post Created", "OK");

        }
    }
}