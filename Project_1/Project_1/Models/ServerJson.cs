﻿using System;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Project_1.Models
{
    class ServerJson
    {
        /* GetResponseAsync() Method can't be used as it does not support Windows phone 8 
        * Since we are don't have support for Windows Phone 8 the method should be availble but future investigation into the WebReponse Class showed that the method was missing for some reason.
        * 
        * Steps Taken to tried re-enabling
        * Manual import of System.Net.Http (Still didn't work)
        * 
        * Found another way to handle HttpRequest by using HttpClient() method found in the HttpClient class
        * Tutorial can be found here 
        * https://blog.jayway.com/2012/03/13/httpclient-makes-get-and-post-very-simple/
        * 
        * 
        *   
        *
        *   
        * 
       public async void Save(Question name, Question password)
       {
           try
           {
               Debug.WriteLine("Test User.save");

               string actualUrl = url + "&action=save&objectid=" + name + ".user" + "&data=" + password;

               Uri uri = new Uri(actualUrl);

               Debug.WriteLine(uri);

               HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
               request.ContentType = "application/json";
               request.Method = "GET";

               using (WebResponse response = await request.GetResponseAsync())
               {
                   using (Stream stream = response.GetResponseStream())
                   {
                       StreamReader objStream = new StreamReader(stream);
                       string sLine = "";

                       while (sLine != null)
                       {
                           sLine = objStream.ReadLine();
                           if (sLine != null)
                           {
                               Debug.WriteLine(sLine);
                           }
                       }
                   }

               }
           }
           catch
           {

           }
       }
       */

        //Server URL that we are going to store our JSON data to
        private static string url = "http://introtoapps.com/datastore.php?appid=213107696";
        private static string userData = "userData";
        private static string questionData = "questionData";

        public async void SendToServer(Uri uri)
        {
            var httpClient = new HttpClient();
            await httpClient.GetAsync(uri);
        }   
        public void Save(User NewUser)
        {
            /* This string "actualUrl" Attaches the API commands that we need to talk to the server with our JSON file
             * objectid identifies which JSON object are we targeting 
             * .user is the prefix we use to identify our users
             * data= is the JSON data we are about to send to the server
             * We wrap our data in [] to create an array
            */
            string saveUrl = url + "&action=append&objectid=" + userData + "&data=" + NewUser.ToJsonString();
            Uri uri = new Uri(saveUrl);
            Debug.WriteLine("...Storing new User to our server...");
            SendToServer(uri);
            Debug.WriteLine("New User Stored!");

        }
        public void NewQuestion(Question NewQuestion)
        {
            string replyQuestion = "Comments below are replies";   
            ReplyQuestion NewReply = ReplyQuestion.CreateReplyFromJson("{\"Reply\":\"" + replyQuestion + "\"}");

            string newQuestionUrl = url + "&action=append&objectid=" + questionData + "&data=" + NewQuestion.ToJsonString();
            string newReplyUrl = url + "&action=save&objectid=" + NewQuestion.Title + "&data=[" + NewReply.ToJsonString() + "]";

            Uri uri = new Uri(newQuestionUrl);
            Uri newReplyUri = new Uri(newReplyUrl);

            SendToServer(uri);
            SendToServer(newReplyUri);
        }
        public void Reply(Question qTitle, ReplyQuestion Reply)
        {
            string newReplyUrl = url + "&action=append&objectid=" + qTitle.Title + "&data=" + Reply.ToJsonString();
            Uri uri = new Uri(newReplyUrl);
            SendToServer(uri);
        }
        public async Task<bool> CheckUserPasswordAsync(string username, string password)
        {
            //string Title = "Title";
            //string ForumQuestion = "Question";
            //string Desc = "Description";
            ////Creates a NewQuestion object and uses the data from the user and creates a JSON formatted data structure
            //Question initalizedq = Question.CreateQuestionFromJson("{\"Title\":\"" + Title + "\", \"ForumQuestion\":\"" + ForumQuestion + "\", \"Description\":\"" + Desc + "\"}");
            //NewQuestion(initalizedq);

            bool logginChecker = false;
            
            string loadUrl = url + "&action=load&objectid=" + userData;
            Uri uri = new Uri(loadUrl);

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);

            string content = await response.Content.ReadAsStringAsync();

            User[] myUsers = JsonConvert.DeserializeObject<User[]>(content);

            foreach (User users in myUsers)
            {
                if (users.Username.Equals(username))
                {
                    Debug.WriteLine("We found our tragetted username");
                    if (users.Password.Equals(password))
                    {
                        Debug.WriteLine("Username and password matches!");
                        return logginChecker = true;
                    }
                }
            }
            return logginChecker;
        }
        public async Task<Question[]> RetrieveQuestions()
        {
            string loadUrl = url + "&action=load&objectid=" + questionData;
            Uri uri = new Uri(loadUrl);

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            string content = await response.Content.ReadAsStringAsync();

            Question[] myQuestions = JsonConvert.DeserializeObject<Question[]>(content.ToString());
            return myQuestions;
        }
        public async Task<ReplyQuestion[]> RetrieveReply(Question qTitle)
        {
            Question temp = qTitle;
            string loadUrl = url + "&action=load&objectid=" + qTitle.Title;
            Uri uri = new Uri(loadUrl);

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            string content = await response.Content.ReadAsStringAsync();

            ReplyQuestion[] myReply = JsonConvert.DeserializeObject<ReplyQuestion[]>(content.ToString());

            return myReply;
        }
    }
}
