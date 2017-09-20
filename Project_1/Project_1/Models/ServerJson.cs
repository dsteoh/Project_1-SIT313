﻿using System;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;
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
        private static string userBlob = "userData";

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
             * 
             * We wrap our data in [] to create an array
            */

            Debug.WriteLine("Creating new User");
            string saveUrl = url + "&action=append&objectid=" + userBlob + "&data=" + NewUser.ToJsonString();
            Uri uri = new Uri(saveUrl);
            SendToServer(uri);
        }

        public async void CheckUserPasswordAsync(string username, string password)
        {
            
            string loadUrl = url + "&action=load&objectid=" + userBlob;
            Uri uri = new Uri(loadUrl);

            Debug.WriteLine("Starting http service CheckUserinServer method");
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);

            Debug.WriteLine("store users in content string");
            string content = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("Adding users to array");
            User[] myUsers = JsonConvert.DeserializeObject<User[]>(content.ToString());

            string x = content.ToString();
            Debug.WriteLine("Check content" + content.ToString());

            Debug.WriteLine("Foreach loop");
            foreach (User users in myUsers)
            {
                Debug.WriteLine("Check users" + users.Username);
                Debug.WriteLine("check if username match");
                if (users.Username.Equals(username))
                {
                    Debug.WriteLine("We found our tragetted username");
                    if (users.Password.Equals(password))
                    {
                        Debug.WriteLine("We Found Matching Passwords!!");
                        return;
                    }
                    Debug.WriteLine("password incorrect");
                }
                Debug.WriteLine("username not found");
            }
        }
    }
}
