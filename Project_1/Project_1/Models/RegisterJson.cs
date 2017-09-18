using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace Project_1.Models
{
    class RegisterJson
    {
        //private static string url = "";

        //public static User CreateUserFromJson(string json)
        //{
        //    User user = JsonConvert.DeserializeObject<User>(json);
        //    return user;
        //}


        //public async void Save(Question name, Question password)
        //{
        //    try
        //    {
        //        Debug.WriteLine("Test User.save");

        //        string actualUrl = url + "&action=save&objectid=" + name + ".user" + "&data=" + password;

        //        Uri uri = new Uri(actualUrl);

        //        Debug.WriteLine(uri);

        //        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
        //        request.ContentType = "application/json";
        //        request.Method = "GET";

        //        using (WebResponse response = await request.GetResponseAsync())
        //        {
        //            using (Stream stream = response.GetResponseStream())
        //            {
        //                StreamReader objStream = new StreamReader(stream);
        //                string sLine = "";

        //                while (sLine != null)
        //                {
        //                    sLine = objStream.ReadLine();
        //                    if (sLine != null)
        //                    {
        //                        Debug.WriteLine(sLine);
        //                    }
        //                }
        //            }

        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //public async Task<bool> Load()
        //{
        //    try
        //    {
        //        string actualUrl = url + "&action=load&objectid=" + this.username + ".user";

        //        Uri uri = new Uri(actualUrl);
        //        Debug.WriteLine(uri);

        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

        //        request.Method = "GET";

        //        using (WebResponse response = await request.GetResponseAsync())
        //        {
        //            using (Stream stream = response.GetResponseStream())
        //            {
        //                StreamReader objStream = new StreamReader(stream);
        //                string sLine = "";

        //                while (sLine != null)
        //                {
        //                    sLine = objStream.ReadLine();
        //                    if (sLine != null)
        //                    {
        //                        this.password = sLine;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);
        //        return false;
        //    }
        //    return true;
        //}
    }
}
