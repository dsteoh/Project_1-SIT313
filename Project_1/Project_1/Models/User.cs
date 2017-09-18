using Newtonsoft.Json;

namespace Project_1.Models
{
    class User
    {
        private string _username;
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public User()
        {

        }

        public User(string username)
        {
            _username = username;
        }

        public User(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public static User CreateUserFromJson(string json)
        {
            User user = JsonConvert.DeserializeObject<User>(json);
            return user;
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
