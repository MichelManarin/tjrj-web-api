using Moq;
using CloudBooks.API.Presentation.Controllers;
using CloudBooks.API.Core.Services;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using CloudBooks.API.Presentation.ViewModel;
using CloudBooks.UnitTests.Helpers;

namespace CloudBooks.UnitTests.Systems.Controllers;

public class TestLivroController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        var mockLivroService = new Mock<ILivroService>();

        mockLivroService
            .Setup(service => service.GetAllLivrosAsync())
            .ReturnsAsync(new List<Livro>());

        var sut = new LivroControllerFixture(mockLivroService).CreateController();

        var result = (OkObjectResult)await sut.GetLivros();

        result.StatusCode.Should().Be(200);
    }


    [Fact]
    public async Task Get_OnSuccess_InvokesLivroService()
    {
        var mockLivroService = new Mock<ILivroService>();

        mockLivroService
            .Setup(service => service.GetAllLivrosAsync())
            .ReturnsAsync(new List<Livro>());

        var sut = new LivroControllerFixture(mockLivroService).CreateController();

        var result = await sut.GetLivros();

        mockLivroService.Verify(service =>
            service.GetAllLivrosAsync(),
            Times.Once()
        );
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfLivroes()
    {
        var mockLivroService = new Mock<ILivroService>();

        mockLivroService
            .Setup(service => service.GetAllLivrosAsync())
            .ReturnsAsync(new List<Livro>());

        var sut = new LivroControllerFixture(mockLivroService).CreateController();

        var result = await sut.GetLivros();

        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<LivroViewModel>>();
    }

    [Fact]
    public async void Post_OnSuccess_ReturnsOkObject()
    {
        var mockLivroService = new Mock<ILivroService>();

        var fakeLivro = TestDataGenerator.CreateFakeLivroViewModel();

        var sut = new LivroControllerFixture(mockLivroService).CreateController();

        var result = await sut.Add(fakeLivro);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Post_OnSuccess_InvokesLivroService()
    {
        var mockLivroService = new Mock<ILivroService>();

        var fakeLivroView = TestDataGenerator.CreateFakeLivroViewModel();
        var fakeLivroModel = TestDataGenerator.CreateFakeLivroModel();

        mockLivroService
            .Setup(service => service.AddLivroAsync(fakeLivroModel));

        var sut = new LivroControllerFixture(mockLivroService).CreateController();

        var result = sut.Add(fakeLivroView);

        mockLivroService.Verify(service =>
            service.AddLivroAsync(It.Is<Livro>(c =>
                c.Titulo == fakeLivroView.Titulo &&
                c.AnoPublicacao == fakeLivroModel.AnoPublicacao &&
                c.Edicao == fakeLivroModel.Edicao && 
                c.Editora == fakeLivroModel.Editora)), Times.Once);
    }

    [Fact]
    public async void Delete_OnDelete_ReturnsNoContent()
    {
        var mockLivroService = new Mock<ILivroService>();

        var fakeLivro = TestDataGenerator.CreateFakeLivroViewModel();

        var sut = new LivroControllerFixture(mockLivroService).CreateController();

        var result = await sut.Remove(TestDataGenerator.CreateFakeLivroId());

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async void Delete_OnDelete_InvokesLivroService()
    {
        var mockLivroService = new Mock<ILivroService>();

        var fakeLivroView = TestDataGenerator.CreateFakeLivroViewModel();
        var fakeLivroModel = TestDataGenerator.CreateFakeLivroModel();

        mockLivroService
            .Setup(service => service.AddLivroAsync(fakeLivroModel));

        var sut = new LivroControllerFixture(mockLivroService).CreateController();

        var result = await sut.Remove(TestDataGenerator.CreateFakeLivroId());

        mockLivroService.Verify(
            service => service.RemoveLivroAsync(It.IsAny<int>()),
            Times.Once()
        );
    }

    [Fact]
    public async void Patch_OnPatch_ReturnsOk()
    {
        var mockLivroService = new Mock<ILivroService>();

        var fakeLivro = TestDataGenerator.CreateFakeLivroViewModel();

        var sut = new LivroControllerFixture(mockLivroService).CreateController();

        var result = await sut.Update(fakeLivro);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async void Patch_OnPatch_InvokesLivroService()
    {
        var mockLivroService = new Mock<ILivroService>();

        var fakeLivroView = TestDataGenerator.CreateFakeLivroViewModel();
        var fakeLivroModel = TestDataGenerator.CreateFakeLivroModel();

        mockLivroService
            .Setup(service => service.AddLivroAsync(fakeLivroModel));

        var sut = new LivroControllerFixture(mockLivroService).CreateController();

        var result = await sut.Update(fakeLivroView);

        mockLivroService.Verify(service =>
            service.UpdateLivroAsync(It.Is<Livro>(c =>
                c.AnoPublicacao == fakeLivroView.AnoPublicacao &&
                c.Edicao == fakeLivroView.Edicao &&
                c.Titulo == fakeLivroView.Titulo &&
                c.Editora == fakeLivroView.Editora &&
                c.Titulo == fakeLivroView.Titulo &&
                c.Codl == fakeLivroView.Codl)), Times.Once);
    }
}