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
    public partial class Reply : ContentPage
    {
        string selectedTopic;
        Question tempStore = new Question();

        public Reply(Question selectedTitle)
        {
            InitializeComponent();
            selectedTopic = selectedTitle.Title;
            tempStore = selectedTitle;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string replyQuestion = replyEdit.Text;
            //Creates a NewQuestion object and uses the data from the user and creates a JSON formatted data structure
            ReplyQuestion NewReply = ReplyQuestion.CreateReplyFromJson("{\"Reply\":\"" + replyQuestion + "\"}");

            /* Passes QuestionJson object with our JSON format to the RegisterJson object 
             * RegisterJson object contains the method Save() which contacts the server
             */
            ServerJson ReplyQuestionJson = new ServerJson();
            Debug.WriteLine("sending newq to severjson");
            ReplyQuestionJson.Reply(tempStore, NewReply);
            await DisplayAlert("Alert", "New Reply Posted", "OK");

        }
    }
}