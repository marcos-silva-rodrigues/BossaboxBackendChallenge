using Microsoft.EntityFrameworkCore;

namespace BossaboxBackendChallenge.Model
{
    public class Tool
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        private List<Tag> _tags { get; set; }

        public virtual string[] Tags { get
            {
                return _tags.Select(tag => tag.Name).ToArray();
            } }


        public Tool(string title, string link, string description, string[] tags)
        {
            Id = Guid.NewGuid();
            Title = title;
            Link = link;
            Description = description;
            _tags = new List<Tag>() { };
            foreach (var tag in tags)
            {
                _tags.Add(new Tag(tag));
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Tool tool &&
                   Id.Equals(tool.Id);
        }
    }
}