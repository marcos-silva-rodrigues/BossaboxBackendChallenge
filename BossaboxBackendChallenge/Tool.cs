namespace BossaboxBackendChallenge
{
    public class Tool
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }

        public Tool(string title, string link, string description, string[] tags)
        {
            this.Title = title;
            this.Link = link;
            this.Description = description;
            this.Tags = tags;
        }
    }
}