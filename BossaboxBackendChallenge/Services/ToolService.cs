using BossaboxBackendChallenge.Model;

namespace BossaboxBackendChallenge.Services
{
    public class ToolService : IToolService
    {
        private List<Tool> _repositorio;

        public ToolService()
        {
            _repositorio = new List<Tool>();
        }
        public Tool CreateTool(string title, string link, string description, string[] tags)
        {
            var newTool = new Tool(
                title,
                link,
                description,
                tags
                );
            _repositorio.Add(newTool);
            return newTool;
        }

        public bool DeleteById(Guid id)
        {
            var tool = _repositorio.FirstOrDefault(tool => tool.Id == id);
            if (tool != null)
            {
                _repositorio.Remove(tool);
                return true;
            }
            return false;
        }

        public Tool? FindToolById(Guid id)
        {
            return _repositorio.FirstOrDefault(tool => tool.Id == id);
        }

        public List<Tool> FindAllToolByTag(string tagName)
        {
            return _repositorio.Where(tool => tool.Tags.Contains(tagName)).ToList();
        }
    }
}
