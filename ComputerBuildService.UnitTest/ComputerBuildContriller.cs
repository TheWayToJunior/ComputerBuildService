using ComputerBuildService.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace ComputerBuildService.UnitTest
{
    public class ComputerBuildContriller
    {
        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            var mock = new Mock<ILogger<ComputerBuildController>>();
            ILogger<ComputerBuildController> logger = mock.Object;

            var controller = new ComputerBuildController(logger);

            // Act
            ActionResult<int> okResult = await controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
