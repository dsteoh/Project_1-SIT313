using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Models
{
    class ReplyQuestion
    {
        private string _reply;

        public string Reply
        {
            get { return _reply; }
            set { _reply = value; }
        }

        public ReplyQuestion()
        {

        }
        
        public static ReplyQuestion CreateReplyFromJson(string json)
        {
            ReplyQuestion reply = JsonConvert.DeserializeObject<ReplyQuestion>(json);
            return reply;
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
