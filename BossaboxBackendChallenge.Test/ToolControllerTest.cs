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


        [Fact]
        public void ShouldReturnToolWithStatus200()
        {
            var mockTool = new Tool("vscode", "vscode", "vscode", new[] { "vscode" });
            var mockServ = new Mock<IToolService>();
            mockServ.Setup(service =>
                service.FindToolById(mockTool.Id)).Returns(mockTool);
            var controller = new ToolController(mockServ.Object);

            var response = controller.GetToolById(mockTool.Id);

            var result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(200, result.StatusCode);

            var value = Assert.IsType<Tool>(result.Value);
            Assert.NotNull(value);
        }

        [Fact]
        public void ShouldReturnStatus404()
        {
            var mockServ = new Mock<IToolService>();
            mockServ.Setup(service =>
                service.FindToolById(It.IsAny<Guid>())).Returns((Tool) null);
            var controller = new ToolController(mockServ.Object);
            var result = controller.GetToolById(Guid.NewGuid());

            var teste = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, teste.StatusCode);
        }

        [Fact]
        public void ShouldReturnAllToolByTag()
        {
            var mockTool1 = new Tool("visualstudio", "vscode", "visualstudio", new[] { "ide", });
            var mockTool2 = new Tool("vscode", "vscode", "vscode", new[] { "ide" });
            var responseMock = new List<Tool>() { mockTool1, mockTool2 };
            var mockServ = new Mock<IToolService>();
            mockServ.Setup(service =>
                service.FindAllToolByTag("ide")).Returns(responseMock);
            var controller = new ToolController(mockServ.Object);

            var response = controller.GetAllToolsByTag("ide");

            var result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(200, result.StatusCode);

            var value = Assert.IsType<List<Tool>>(result.Value);
            Assert.NotNull(value);
            Assert.Equal(2, value.Count);
        }

        [Fact]
        public void ShouldReturnNotFoundWhenReceiptArrayWithoutTool()
        {
           
            var responseMock = new List<Tool>() { };
            var mockServ = new Mock<IToolService>();
            mockServ.Setup(service =>
                service.FindAllToolByTag("ide")).Returns(responseMock);
            var controller = new ToolController(mockServ.Object);

            var response = controller.GetAllToolsByTag("ide");

            var result = Assert.IsType<NotFoundResult>(response);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public void ShouldReturnNoContentWhenDeleteTool()
        {
            var mockServ = new Mock<IToolService>();
            mockServ.Setup(service =>
                service.DeleteById(It.IsAny<Guid>())).Returns(true);
            var controller = new ToolController(mockServ.Object);

            var response = controller.DeleteToolByID(Guid.NewGuid());

            var result = Assert.IsType<NoContentResult>(response);
            Assert.Equal(204, result.StatusCode);
        }

        [Fact]
        public void ShouldReturnNoFoundIfNotFindToolForDelete()
        {
            var mockServ = new Mock<IToolService>();
            mockServ.Setup(service =>
                service.DeleteById(It.IsAny<Guid>())).Returns(false);
            var controller = new ToolController(mockServ.Object);

            var response = controller.DeleteToolByID(Guid.NewGuid());

            var result = Assert.IsType<NotFoundResult>(response);
            Assert.Equal(404, result.StatusCode);
        }
    }
}
