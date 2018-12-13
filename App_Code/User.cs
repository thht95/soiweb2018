namespace BTLweb
{
    internal class User
    {
        public string user { get; set; }
        public string url { get; set; }

        public User()
        {

        }
        public User(string user, string url)
        {
            this.user = user;
            this.url = url;
        }
    }
}