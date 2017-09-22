using System;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net;

namespace Project_1.Models
{
    /// <summary>
    /// This class handles all the JSON server data connection
    /// </summary>
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

        /// <summary>
        /// Takes the uri and send it to our json server
        /// </summary>
        /// <param name="uri"></param>
        public async void SendToServer(Uri uri)
        {
            //Connecting to the server
            var httpClient = new HttpClient();
            //Pusing our data to the server
            await httpClient.GetAsync(uri);
        }   
        /// <summary>
        /// Saves users to userData array
        /// </summary>
        /// <param name="NewUser"></param>
        public void Save(User NewUser)
        {
            /* This string "actualUrl" Attaches the API commands that we need to talk to the server with our JSON file
             * objectid identifies which JSON object are we targeting 
             * .user is the prefix we use to identify our users
             * data= is the JSON data we are about to send to the server
            */
            string saveUrl = url + "&action=append&objectid=" + userData + "&data=" + NewUser.ToJsonString();
            Uri uri = new Uri(saveUrl);
            Debug.WriteLine("...Storing new User to our server...");
            SendToServer(uri);
            Debug.WriteLine("New User Stored!");

        }
        /// <summary>
        /// Creates a new Questions inside the JSON questionData array + create a new array for replies
        /// </summary>
        /// <param name="NewQuestion"></param>
        public void NewQuestion(Question NewQuestion)
        {
            string replyQuestion = "Comments below are replies";   
            ReplyQuestion NewReply = ReplyQuestion.CreateReplyFromJson("{\"Reply\":\"" + replyQuestion + "\"}");

            string spaceRemoved = NewQuestion.Title.Replace(" ", string.Empty);

            string Qjson = WebUtility.UrlEncode(NewQuestion.ToJsonString());
            string Rjson = WebUtility.UrlEncode(NewReply.ToJsonString());

            string newQuestionUrl = url + "&action=append&objectid=" + questionData + "&data=" + Qjson;
            string newReplyUrl = url + "&action=append&objectid=" + spaceRemoved + "&data=[" + Rjson + "]";

            Uri uri = new Uri(newQuestionUrl);
            Uri newReplyUri = new Uri(newReplyUrl);

            SendToServer(uri);
            SendToServer(newReplyUri);
        }
        /// <summary>
        /// This method takes the Question title that is targetted into param qTitle this allows us to create a new array called Question.Title (eg HowToCode?) 
        /// Which will allow us to easily identify the array to target and append new replies to it
        /// </summary>
        /// <param name="qTitle"></param>
        /// <param name="Reply"></param>
        public void Reply(Question qTitle, ReplyQuestion Reply)
        {
            string replyJson = WebUtility.UrlEncode(Reply.ToJsonString());
            string spaceRemoved = qTitle.Title.Replace(" ", string.Empty);

            string newReplyUrl = url + "&action=append&objectid=" + spaceRemoved + "&data=" + replyJson;
            Uri uri = new Uri(newReplyUrl);
            SendToServer(uri);
        }
        /// <summary>
        /// Takes username and password and check if they match
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> CheckUserPasswordAsync(string username, string password)
        {
            bool logginChecker = false;
            
            string loadUrl = url + "&action=load&objectid=" + userData;
            Uri uri = new Uri(loadUrl);

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);

            string content = await response.Content.ReadAsStringAsync();

            //Takes all the users from the json array and stores it in an array type User 
            User[] myUsers = JsonConvert.DeserializeObject<User[]>(content);
            //Check if user exsits
            foreach (User users in myUsers)
            {
                if (users.Username.Equals(username))
                {
                    Debug.WriteLine("We found our tragetted username");
                    //Checks if username entered matches the password
                    if (users.Password.Equals(password))
                    {
                        Debug.WriteLine("Username and password matches!");
                        return logginChecker = true;
                    }
                }
            }
            return logginChecker;
        }
        /// <summary>
        /// Returns all the questions to an array of Questions[]
        /// </summary>
        /// <returns></returns>
        public async Task<Question[]> RetrieveQuestions()
        {
            string loadUrl = url + "&action=load&objectid=" + questionData;
            Uri uri = new Uri(loadUrl);

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            string content = await response.Content.ReadAsStringAsync();

            string decoded = WebUtility.UrlDecode(content);
            Question[] myQuestions = JsonConvert.DeserializeObject<Question[]>(decoded);
            return myQuestions;
        }
        /// <summary>
        /// Method returns all replies from the Question targetted 
        /// </summary>
        /// <param name="qTitle"></param>
        /// <returns></returns>
        public async Task<ReplyQuestion[]> RetrieveReply(Question qTitle)
        {
            Question temp = qTitle;
            string spaceRemoved = qTitle.Title.Replace(" ", string.Empty);

            string loadUrl = url + "&action=load&objectid=" + spaceRemoved;
            Uri uri = new Uri(loadUrl);

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            string content = await response.Content.ReadAsStringAsync();

            ReplyQuestion[] myReply = JsonConvert.DeserializeObject<ReplyQuestion[]>(content.ToString());

            return myReply;
        }
    }
}
