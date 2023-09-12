namespace BossaboxBackendChallenge.Model
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
            Id = Guid.NewGuid();
            Title = title;
            Link = link;
            Description = description;
            Tags = tags;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tool tool &&
                   Id.Equals(tool.Id);
        }
    }
}