using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BossaboxBackendChallenge.Test
{
    public class ToolControllerTest
    {

        [Fact]
        public void ShouldReturnCreatedStatusForNewTool()
        {
            var mockServ = new Mock<IToolService>();
            mockServ.Setup(service =>
                service.CreateTool(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string[]>()
                    )).Returns(new Tool("vscode", "vscode", "vscode", new[] { "vscode" }));
            var controller = new ToolController(mockServ.Object);

            CreatedToolDto mockRequestBody = new CreatedToolDto
            {
                Title = "vscode",
                Description = "vscode",
                Link = "vscode",
                Tags = new[] { "vscode" }
            };

            var result = controller.CreateToll(mockRequestBody);

            var teste = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, teste.StatusCode);
        }
    }
}
