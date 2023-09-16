using System.ComponentModel.DataAnnotations;

namespace BossaboxBackendChallenge.Model
{
    public class Tag
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual List<Tool> Tools { get; } = new();

        public Tag(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}