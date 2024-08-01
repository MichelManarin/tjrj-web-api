using Moq;
using CloudBooks.API.Presentation.Controllers;
using CloudBooks.API.Core.Services;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using CloudBooks.API.Presentation.ViewModel;
using CloudBooks.UnitTests.Helpers;

namespace CloudBooks.UnitTests.Systems.Controllers;

public class TestAssuntoController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        var mockAssuntoService = new Mock<IAssuntoService>();

        mockAssuntoService
            .Setup(service => service.GetAllAssuntosAsync())
            .ReturnsAsync(new List<Assunto>());

        var sut = new AssuntoControllerFixture(mockAssuntoService).CreateController();

        var result = (OkObjectResult)await sut.Get();

        result.StatusCode.Should().Be(200);
    }


    [Fact]
    public async Task Get_OnSuccess_InvokesAssuntoService()
    {
        var mockAssuntoService = new Mock<IAssuntoService>();

        mockAssuntoService
            .Setup(service => service.GetAllAssuntosAsync())
            .ReturnsAsync(new List<Assunto>());

        var sut = new AssuntoControllerFixture(mockAssuntoService).CreateController();

        var result = await sut.Get();

        mockAssuntoService.Verify(service =>
            service.GetAllAssuntosAsync(),
            Times.Once()
        );
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfAssuntoes()
    {
        var mockAssuntoService = new Mock<IAssuntoService>();

        mockAssuntoService
            .Setup(service => service.GetAllAssuntosAsync())
            .ReturnsAsync(new List<Assunto>());

        var sut = new AssuntoControllerFixture(mockAssuntoService).CreateController();

        var result = await sut.Get();

        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<AssuntoViewModel>>();
    }

    [Fact]
    public async void Post_OnSuccess_ReturnsOkObject()
    {
        var mockAssuntoService = new Mock<IAssuntoService>();

        var fakeAssunto = TestDataGenerator.CreateFakeAssuntoViewModel();

        var sut = new AssuntoControllerFixture(mockAssuntoService).CreateController();

        var result = await sut.Add(fakeAssunto);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Post_OnSuccess_InvokesAssuntoService()
    {
        var mockAssuntoService = new Mock<IAssuntoService>();

        var fakeAssuntoView = TestDataGenerator.CreateFakeAssuntoViewModel();
        var fakeAssuntoModel = TestDataGenerator.CreateFakeAssuntoModel();

        mockAssuntoService
            .Setup(service => service.AddAssuntoAsync(fakeAssuntoModel));

        var sut = new AssuntoControllerFixture(mockAssuntoService).CreateController();

        var result = sut.Add(fakeAssuntoView);

        mockAssuntoService.Verify(service =>
            service.AddAssuntoAsync(It.Is<Assunto>(c =>
                c.Descricao == fakeAssuntoView.Descricao)), Times.Once);
    }

    [Fact]
    public async void Delete_OnDelete_ReturnsNoContent()
    {
        var mockAssuntoService = new Mock<IAssuntoService>();

        var fakeAssunto = TestDataGenerator.CreateFakeAssuntoViewModel();

        var sut = new AssuntoControllerFixture(mockAssuntoService).CreateController();

        var result = await sut.Remove(TestDataGenerator.CreateFakeAssuntoId());

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async void Delete_OnDelete_InvokesAssuntoService()
    {
        var mockAssuntoService = new Mock<IAssuntoService>();

        var fakeAssuntoView = TestDataGenerator.CreateFakeAssuntoViewModel();
        var fakeAssuntoModel = TestDataGenerator.CreateFakeAssuntoModel();

        mockAssuntoService
            .Setup(service => service.AddAssuntoAsync(fakeAssuntoModel));

        var sut = new AssuntoControllerFixture(mockAssuntoService).CreateController();

        var result = await sut.Remove(TestDataGenerator.CreateFakeAssuntoId());

        mockAssuntoService.Verify(
            service => service.RemoveAssuntoAsync(It.IsAny<int>()),
            Times.Once()
        );
    }

    [Fact]
    public async void Patch_OnPatch_ReturnsOk()
    {
        var mockAssuntoService = new Mock<IAssuntoService>();

        var fakeAssunto = TestDataGenerator.CreateFakeAssuntoViewModel();

        var sut = new AssuntoControllerFixture(mockAssuntoService).CreateController();

        var result = await sut.Update(fakeAssunto);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async void Patch_OnPatch_InvokesAssuntoService()
    {
        var mockAssuntoService = new Mock<IAssuntoService>();

        var fakeAssuntoView = TestDataGenerator.CreateFakeAssuntoViewModel();
        var fakeAssuntoModel = TestDataGenerator.CreateFakeAssuntoModel();

        mockAssuntoService
            .Setup(service => service.AddAssuntoAsync(fakeAssuntoModel));

        var sut = new AssuntoControllerFixture(mockAssuntoService).CreateController();

        var result = await sut.Update(fakeAssuntoView);

        mockAssuntoService.Verify(service =>
            service.UpdateAssuntoAsync(It.Is<Assunto>(c =>
                c.CodAs == fakeAssuntoView.CodAs &&
                c.Descricao == fakeAssuntoView.Descricao)), Times.Once);
    }
}