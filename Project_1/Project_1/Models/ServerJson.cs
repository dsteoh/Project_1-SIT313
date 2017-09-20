using System;
using System.Net.Http;
using System.Diagnostics;


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
        private static string userBlob = "userData";

        public async void SendToServer(Uri uri)
        {
            var httpClient = new HttpClient();
            await httpClient.GetAsync(uri);

            //var response = await httpClient.GetAsync(userBlobTest);
            //string content = await response.Content.ReadAsStringAsync();

            //if(String.IsNullOrWhiteSpace(content))
            //{

            //}
            //var response = await httpClient.GetAsync(objectData);
            //response.EnsureSuccessStatusCode();
        }

        public void Save(User NewUser)
        {
            /* This string "actualUrl" Attaches the API commands that we need to talk to the server with our JSON file
             * objectid identifies which JSON object are we targeting 
             * .user is the prefix we use to identify our users
             * data= is the JSON data we are about to send to the server
             * 
             * We wrap our data in [] to create an array
            */

            Debug.WriteLine("Creating new User");
            string saveUrl = url + "&action=append&objectid=" + userBlob + "&data=" + NewUser.ToJsonString();
            Uri uri = new Uri(saveUrl);
            SendToServer(uri);
        }

        public CheckUserPassword(string username)
        {
            string loadUrl = url + "&action=load&objectid=" + userBlob + "&data=" + username;
        }


    }
}
