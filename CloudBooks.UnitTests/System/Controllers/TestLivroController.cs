using Moq;
using CloudBooks.API.Presentation.Controllers;
using CloudBooks.API.Core.Services;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using CloudBooks.API.Presentation.ViewModel;
using CloudBooks.UnitTests.Helpers;

namespace CloudBooks.UnitTests.Systems.Controllers;

public class TestAutorController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        var mockAutorService = new Mock<IAutorService>();

        mockAutorService
            .Setup(service => service.GetAllAtoresAsync())
            .ReturnsAsync(new List<Autor>());

        var sut = new AutorControllerFixture(mockAutorService).CreateController();

        var result = (OkObjectResult)await sut.Get();

        result.StatusCode.Should().Be(200);
    }


    [Fact]
    public async Task Get_OnSuccess_InvokesAutorService()
    {
        var mockAutorService = new Mock<IAutorService>();

        mockAutorService
            .Setup(service => service.GetAllAtoresAsync())
            .ReturnsAsync(new List<Autor>());

        var sut = new AutorControllerFixture(mockAutorService).CreateController();

        var result = await sut.Get();

        mockAutorService.Verify(service =>
            service.GetAllAtoresAsync(),
            Times.Once()
        );
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfAutores()
    {
        var mockAutorService = new Mock<IAutorService>();

        mockAutorService
            .Setup(service => service.GetAllAtoresAsync())
            .ReturnsAsync(new List<Autor>());

        var sut = new AutorControllerFixture(mockAutorService).CreateController();

        var result = await sut.Get();

        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<AutorViewModel>>();
    }

    [Fact]
    public async void Post_OnSuccess_ReturnsOkObject()
    {
        var mockAutorService = new Mock<IAutorService>();

        var fakeAutor = TestDataGenerator.CreateFakeAutorViewModel();

        var sut = new AutorControllerFixture(mockAutorService).CreateController();

        var result = await sut.Add(fakeAutor);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Post_OnSuccess_InvokesAutorService()
    {
        var mockAutorService = new Mock<IAutorService>();

        var fakeAutorView = TestDataGenerator.CreateFakeAutorViewModel();
        var fakeAutorModel = TestDataGenerator.CreateFakeAutorModel();

        mockAutorService
            .Setup(service => service.AddAutorAsync(fakeAutorModel));

        var sut = new AutorControllerFixture(mockAutorService).CreateController();

        var result = sut.Add(fakeAutorView);

        mockAutorService.Verify(service =>
            service.AddAutorAsync(It.Is<Autor>(c =>
                c.Nome == fakeAutorView.Nome)), Times.Once);
    }

    [Fact]
    public async void Delete_OnDelete_ReturnsNoContent()
    {
        var mockAutorService = new Mock<IAutorService>();

        var fakeAutor = TestDataGenerator.CreateFakeAutorViewModel();

        var sut = new AutorControllerFixture(mockAutorService).CreateController();

        var result = await sut.Remove(TestDataGenerator.CreateFakeAutorId());

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async void Delete_OnDelete_InvokesAutorService()
    {
        var mockAutorService = new Mock<IAutorService>();

        var fakeAutorView = TestDataGenerator.CreateFakeAutorViewModel();
        var fakeAutorModel = TestDataGenerator.CreateFakeAutorModel();

        mockAutorService
            .Setup(service => service.AddAutorAsync(fakeAutorModel));

        var sut = new AutorControllerFixture(mockAutorService).CreateController();

        var result = await sut.Remove(TestDataGenerator.CreateFakeAutorId());

        mockAutorService.Verify(
            service => service.RemoveAutorAsync(It.IsAny<int>()),
            Times.Once()
        );
    }

    [Fact]
    public async void Patch_OnPatch_ReturnsOk()
    {
        var mockAutorService = new Mock<IAutorService>();

        var fakeAutor = TestDataGenerator.CreateFakeAutorViewModel();

        var sut = new AutorControllerFixture(mockAutorService).CreateController();

        var result = await sut.Update(fakeAutor);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async void Patch_OnPatch_InvokesAutorService()
    {
        var mockAutorService = new Mock<IAutorService>();

        var fakeAutorView = TestDataGenerator.CreateFakeAutorViewModel();
        var fakeAutorModel = TestDataGenerator.CreateFakeAutorModel();

        mockAutorService
            .Setup(service => service.AddAutorAsync(fakeAutorModel));

        var sut = new AutorControllerFixture(mockAutorService).CreateController();

        var result = await sut.Update(fakeAutorView);

        mockAutorService.Verify(service =>
            service.UpdateAutorAsync(It.Is<Autor>(c =>
                c.CodAu == fakeAutorView.CodAu &&
                c.Nome == fakeAutorView.Nome)), Times.Once);
    }
}