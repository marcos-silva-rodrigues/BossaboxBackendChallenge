using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BossaboxBackendChallenge.Model
{
    public class Tool
    {

        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual List<Tag> Tags { get; } = new();

        [JsonPropertyName("tags")]
        public virtual string[] tagsName { get
            {
                return Tags.Select(t => t.Name).ToArray();
            } }
        public Tool(string title, string link, string description)
        {
            Title = title;
            Link = link;
            Description = description;
        }

        public override bool Equals(object? obj)
        {
            return obj is Tool tool &&
                   Id.Equals(tool.Id);
        }
    }
}