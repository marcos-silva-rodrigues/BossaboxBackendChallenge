using BossaboxBackendChallenge.Services;
using BossaboxBackendChallenge.Test.Mocks;

namespace BossaboxBackendChallenge.Test
{
    public class ToolServiceTest
    {

        [Fact]
        public void ShouldReturnNewTool()
        {
            var service = InitializeToolService();

            var tool = service.CreateTool(
                "Visual Studio",
                "https://visualstudio.microsoft.com/pt-br/vs/", 
                "power idem for c sharp", new []{ "ide", "microsoft", "chsarp", ".net"});

            Assert.NotNull(tool);
            Assert.Equal("Visual Studio", tool.Title);
            Assert.Equal("https://visualstudio.microsoft.com/pt-br/vs/", tool.Link);
            Assert.Equal("power idem for c sharp", tool.Description);

            Assert.Equal(4, tool.Tags.Count());

            var tagnames = tool.Tags.Select(tag => tag.Name).ToList();
            Assert.Contains("chsarp", tagnames);
            Assert.Contains("microsoft", tagnames);
            Assert.Contains("ide", tagnames);
            Assert.Contains(".net", tagnames);
        }

        [Fact]
        public void ShouldGetToolCreated()
        {
            var service = InitializeToolService();
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
            var service = InitializeToolService();
            var tool = service.CreateTool("Visual Studio",
                "https://visualstudio.microsoft.com/pt-br/vs/",
                "power idem for c sharp", new[] { "ide", "microsoft", "chsarp", ".net" });

            var consultTool = service.FindAllToolByTag("ide");

            Assert.Single(consultTool);
            Assert.Contains(tool, consultTool);
        }

        [Fact]
        public void ShouldReturnTrueIfDeleteToolById()
        {
            var service = InitializeToolService();
            var tool = service.CreateTool("Visual Studio",
                "https://visualstudio.microsoft.com/pt-br/vs/",
                "power idem for c sharp", new[] { "ide", "microsoft", "chsarp", ".net" });

            var response = service.DeleteById(tool.Id);
            Assert.True(response);
            var consultTool = service.FindToolById(tool.Id);

            Assert.Null(consultTool);
        }

        [Fact]
        public void ShouldReturnFalseIfNotFindToolById()
        {

            var service = InitializeToolService();
            var response = service.DeleteById(Guid.NewGuid());

            Assert.False(response);
        }

        public ToolService InitializeToolService()
        {
            var context = new MockDB().CreateDbContext();
            return new ToolService(context);
        }

    }
}