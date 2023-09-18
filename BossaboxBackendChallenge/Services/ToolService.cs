using BossaboxBackendChallenge.Data;
using BossaboxBackendChallenge.Model;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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
                var tag = CreateOrReturnTag(tagName);
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
            return _context.Tools.Include(tool => tool.Tags).FirstOrDefault(tool => tool.Id == id);
        }

        public List<Tool> FindAllToolByTag(string tagName)
        {
            var result = _context.Tags.Where(tag => tag.Name.ToLower() == tagName.ToLower()).FirstOrDefault();
            if (result == null) return new List<Tool>();

            return _context.Tools.Include(tool => tool.Tags).Where(tool => tool.Tags.Contains(result)).ToList();

        }

        private Tag CreateOrReturnTag(string name)
        {
            Tag? tag =  _context.Tags.Where
                (tag => tag.Name.ToLower() == name.ToLower())
                .FirstOrDefault();

            if (tag == null)
            {
                var creatdTag = new Tag(name);
                _context.Tags.Add(creatdTag);
                return creatdTag;
            }

            return tag;
        }
    }
}
