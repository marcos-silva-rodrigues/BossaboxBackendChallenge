namespace BossaboxBackendChallenge
{
    public class Tool
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }

        public Tool(string title, string link, string description, string[] tags)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Link = link;
            this.Description = description;
            this.Tags = tags;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tool tool &&
                   Id.Equals(tool.Id);
        }
    }
}