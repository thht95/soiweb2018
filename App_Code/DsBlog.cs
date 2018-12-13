namespace BTLweb
{
    internal class DsBlog
    {
        public string id { get; set; }
        public string img { get; set; }
        public string name { get; set; }
        public string detail { get; set; }

        public DsBlog()
        {

        }

        public DsBlog(string id, string img, string name, string detail)
        {
            this.id = id;
            this.img = img;
            this.name = name;
            this.detail = detail;
        }
    }
}