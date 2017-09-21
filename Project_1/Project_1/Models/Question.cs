using Newtonsoft.Json;
using System.Collections.Generic;

namespace Project_1.Models
{
    public class Question
    {
        private string _title;
        private string _forumQuestion;
        private string _description;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string ForumQuestion
        {
            get { return _forumQuestion; }
            set { _forumQuestion = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public Question()
        {

        }

        public static Question CreateQuestionFromJson(string json)
        {
            Question question = JsonConvert.DeserializeObject<Question>(json);
            return question;
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}


