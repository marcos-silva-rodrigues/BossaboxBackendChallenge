namespace BossaboxBackendChallenge
{
    public interface IToolService
    {
        public Tool CreateTool(string title, string link, string description, string[] tags);

        public void DeleteById(Guid id);

        public Tool? FindToolById(Guid id);
        public List<Tool> FindAllToolByTag(string tagName);
    }
}
