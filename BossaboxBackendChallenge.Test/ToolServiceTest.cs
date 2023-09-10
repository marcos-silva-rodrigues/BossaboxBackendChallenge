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

        [Fact]
        public void ShouldGetToolCreated()
        {
            ToolService service = new ToolService();
            var tool = service.CreateTool("Visual Studio",
                "https://visualstudio.microsoft.com/pt-br/vs/",
                "power idem for c sharp", new[] { "ide", "microsoft", "chsarp", ".net" });

            var consultTool = service.FindToolById(tool.Id);

            Assert.NotNull(tool);
            Assert.NotNull(consultTool);
            Assert.Equal(tool.Id, consultTool.Id);
            Assert.True(tool.Equals(consultTool));
        }

        [Fact]
        public void ShouldReturnAllToolByTag()
        {
            ToolService service = new ToolService();
            var tool = service.CreateTool("Visual Studio",
                "https://visualstudio.microsoft.com/pt-br/vs/",
                "power idem for c sharp", new[] { "ide", "microsoft", "chsarp", ".net" });

            var consultTool = service.FindToolByTag("ide");

            Assert.Single(consultTool);
            Assert.Contains(tool, consultTool);
        }

        [Fact]
        public void ShouldDeleteToolById()
        {
            ToolService service = new ToolService();
            var tool = service.CreateTool("Visual Studio",
                "https://visualstudio.microsoft.com/pt-br/vs/",
                "power idem for c sharp", new[] { "ide", "microsoft", "chsarp", ".net" });

            service.DeleteById(tool.Id);
            var consultTool = service.FindToolById(tool.Id);

            Assert.Null(consultTool);
        }

    }
}