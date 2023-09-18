using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BossaboxBackendChallenge.Model
{
    public class Tag
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tool> Tools { get; set; }

        public Tag(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}