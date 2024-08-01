using Microsoft.Extensions.Logging;
using Moq;
using CloudBooks.API.Presentation.Controllers;
using CloudBooks.API.Core.Services;

public class AutorControllerFixture
{
    public Mock<IAutorService> MockAutorService { get; private set; }
    public Mock<ILogger<AutorController>> MockLogger { get; private set; }
    public AutorControllerFixture(
        Mock<IAutorService>? mockAutorService = null,
        Mock<ILogger<AutorController>>? mockLogger = null)
    {
        MockAutorService = mockAutorService ?? new Mock<IAutorService>();
        MockLogger = mockLogger ?? new Mock<ILogger<AutorController>>();
    }

    public AutorController CreateController()
    {
        return new AutorController(MockAutorService.Object, MockLogger.Object);
    }
}