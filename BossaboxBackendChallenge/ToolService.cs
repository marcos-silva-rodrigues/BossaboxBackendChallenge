namespace BossaboxBackendChallenge
{
    public class ToolService
    {
        public Tool CreateTool(string title, string link, string description, string[] tags)
        {
            return new Tool(
                title,
                link,
                description,
                tags
                );
        }
    }
}
