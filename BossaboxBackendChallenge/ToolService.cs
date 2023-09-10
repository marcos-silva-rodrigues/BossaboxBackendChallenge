namespace BossaboxBackendChallenge
{
    public class ToolService
    {
        private List<Tool> _repositorio;

        public ToolService()
        {
            this._repositorio = new List<Tool>();
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

        public void DeleteById(Guid id)
        {
            var tool = _repositorio.FirstOrDefault(tool => tool.Id == id);
            _repositorio.Remove(tool);
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
