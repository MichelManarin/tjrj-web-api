using Microsoft.Extensions.Logging;
using Moq;
using CloudBooks.API.Presentation.Controllers;
using CloudBooks.API.Core.Services;

public class AssuntoControllerFixture
{
    public Mock<IAssuntoService> MockAssuntoService { get; private set; }
    public Mock<ILogger<AssuntoController>> MockLogger { get; private set; }
    public AssuntoControllerFixture(
        Mock<IAssuntoService>? mockAssuntoService = null,
        Mock<ILogger<AssuntoController>>? mockLogger = null)
    {
        MockAssuntoService = mockAssuntoService ?? new Mock<IAssuntoService>();
        MockLogger = mockLogger ?? new Mock<ILogger<AssuntoController>>();
    }

    public AssuntoController CreateController()
    {
        return new AssuntoController(MockAssuntoService.Object, MockLogger.Object);
    }
}