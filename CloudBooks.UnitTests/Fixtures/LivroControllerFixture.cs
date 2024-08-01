using Microsoft.Extensions.Logging;
using Moq;
using CloudBooks.API.Presentation.Controllers;
using CloudBooks.API.Core.Services;

public class LivroControllerFixture
{
    public Mock<ILivroService> MockLivroService { get; private set; }
    public Mock<ILogger<LivroController>> MockLogger { get; private set; }
    public LivroControllerFixture(
        Mock<ILivroService>? mockLivroService = null,
        Mock<ILogger<LivroController>>? mockLogger = null)
    {
        MockLivroService = mockLivroService ?? new Mock<ILivroService>();
        MockLogger = mockLogger ?? new Mock<ILogger<LivroController>>();
    }

    public LivroController CreateController()
    {
        return new LivroController(MockLivroService.Object, MockLogger.Object);
    }
}