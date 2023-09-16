using BossaboxBackendChallenge.Data;
using BossaboxBackendChallenge.Model;

namespace BossaboxBackendChallenge.Services
{
    public class ToolService : IToolService
    {
        private readonly ToolContext _context;

        public ToolService(ToolContext context)
        {
            _context = context;
        }
     
        public Tool CreateTool(string title, string link, string description, string[] tags)
        {
            var newTool = new Tool(
                title,
                link,
                description
                );

            foreach (var tagName in tags)
            {
                var tag = new Tag(tagName);
                _context.Tags.Add(tag);
                newTool.Tags.Add(tag);
            }
            _context.Tools.Add(newTool);
            _context.SaveChanges();
            return newTool;
        }

        public bool DeleteById(Guid id)
        {
            var tool = _context.Tools.FirstOrDefault(tool => tool.Id == id);
            if (tool != null)
            {
                _context.Remove(tool);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Tool? FindToolById(Guid id)
        {
            return _context.Tools.FirstOrDefault(tool => tool.Id == id);
        }

        public List<Tool> FindAllToolByTag(string tagName)
        {
            var result = _context.Tags.Where(tag => tag.Name == tagName).FirstOrDefault();
            if (result == null) return new List<Tool>();

            return _context.Tools.Where(tool => tool.Tags.Contains(result)).ToList();

        }
    }
}
