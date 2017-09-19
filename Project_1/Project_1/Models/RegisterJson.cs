using System;
using System.Net.Http;

namespace Project_1.Models
{
    class RegisterJson
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

        //string actualUrl = url + "&action=load&objectid=" + this.username + ".user";
        //string saveUser = url + "&action=save&objectid=" + name + ".user" + "&data=" + password;

        public async void Save(Uri uri)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);

            //will throw an exception if not successful
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
        }

        

     
    }
}
