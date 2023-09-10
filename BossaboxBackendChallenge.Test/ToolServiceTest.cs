namespace BossaboxBackendChallenge.Test
{
    public class ToolServiceTest
    {
        [Fact]
        public void ShouldReturnNewTool()
        {
            ToolService service = new ToolService();
            var tool = service.CreateTool("Visual Studio",
                "https://visualstudio.microsoft.com/pt-br/vs/", 
                "power idem for c sharp",new []{ "ide", "microsoft", "chsarp", ".net"});

            Assert.NotNull(tool);
            Assert.Equal("Visual Studio", tool.Title);
            Assert.Equal("https://visualstudio.microsoft.com/pt-br/vs/", tool.Link);
            Assert.Equal("power idem for c sharp", tool.Description);
            Assert.Equal(4, tool.Tags.Count());
            Assert.Contains("chsarp", tool.Tags);
            Assert.Contains("microsoft", tool.Tags);
            Assert.Contains("ide", tool.Tags);
            Assert.Contains(".net", tool.Tags);
        }
    }
}