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
        public virtual ICollection<Tag> Tags { get; set; }

        [JsonPropertyName("tags")]
        public virtual string[] TagsName { get { 
                return Tags.Select(t => t.Name).ToArray();  
            } }

        public Tool(string title, string link, string description)
        {
            Title = title;
            Link = link;
            Description = description;
            Tags = new List<Tag>();
        }

        public override bool Equals(object? obj)
        {
            return obj is Tool tool &&
                   Id.Equals(tool.Id);
        }
    }
}