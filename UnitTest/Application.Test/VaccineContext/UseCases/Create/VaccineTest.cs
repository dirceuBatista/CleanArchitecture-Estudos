using Application.SharedContext.Repositories.Abstractions;

using Application.VaccineContext.Repositories.Abstractions;
using Application.VaccineContext.UseCases.Create;
using Core.VaccineContext.Entities;
using Core.VaccineContext.Enums;
using Moq;

namespace Application.Test.VaccineContext.UseCases.Create;

public class CreateVaccineHandlerTest
{
private readonly Mock<IVaccineRepository> _repositoryMock;
private readonly Mock<IUnitOfWork> _unitOfWorkMock;
private readonly VaccineHandler _handler;

public CreateVaccineHandlerTest()
{
    _repositoryMock = new Mock<IVaccineRepository>();
    _unitOfWorkMock = new Mock<IUnitOfWork>();
    _handler = new VaccineHandler(_repositoryMock.Object, _unitOfWorkMock.Object);
}
[Fact]
    public async Task Handle_ReturnsFailure_WhenVaccineAlreadyExists()
    {
        var request = new VaccineCommand("BCG", "Fábrica X", VaccineCategory.Adult, VaccineDose.First, 0,true,  "Vac-1");
        

        _repositoryMock.Setup(r => r.VaccineExistAsync(request.Index))
            .ReturnsAsync(true); 

       
        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Error);
    }
    [Fact]
    public async Task Handle_ReturnsSuccess_WhenVaccineCreated()
    {
        var request = new VaccineCommand("BCG", "Fábrica X", VaccineCategory.Adult, VaccineDose.First, 0,true,  "Vac-1");

        _repositoryMock.Setup(r => r.VaccineExistAsync(request.Index))
            .ReturnsAsync(false);

        _repositoryMock.Setup(r => r.SaveAsync(It.IsAny<Vaccine>()))
            .Returns(Task.CompletedTask);

        _unitOfWorkMock.Setup(u => u.CommitAsync())
            .Returns(Task.CompletedTask);

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal("BCG", result.Value.Name);
        _repositoryMock.Verify(r => r.SaveAsync(It.IsAny<Vaccine>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
    }
    [Fact]
    public async Task Handle_ReturnsFailure_OnException()
    {
       
        var request = new VaccineCommand("BCG", "Fábrica X", VaccineCategory.Adult, VaccineDose.First, 0,true,  "Vac-1");
        
        _repositoryMock.Setup(r => r.VaccineExistAsync(request.Index))
            .ReturnsAsync(false);

        _repositoryMock.Setup(r => r.SaveAsync(It.IsAny<Vaccine>()))
            .ThrowsAsync(new Exception("Erro inesperado"));
        
        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Error);
    }
    

}