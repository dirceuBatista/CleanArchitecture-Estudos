using Application.SharedContext.Repositories.Abstractions;
using Application.VaccineCardContext.Repositories.Abstractions;
using Application.VaccineCardContext.UseCases.Update;
using Application.VaccineContext.Repositories.Abstractions;
using Core.VaccineCardContext.Entities;
using Core.VaccineContext.Entities;
using Core.VaccineContext.Enums;
using Moq;

namespace Application.Test.VaccineCardContext.UseCases.Update;

public class VaccineCardHandlerTest
{
    private readonly Mock<IVaccineCardRepository> _repositoryMock;
    private readonly Mock<IVaccineRepository> _vaccineRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly VaccineCardHandler _handler;
        
    public VaccineCardHandlerTest()
    {
        _repositoryMock = new Mock<IVaccineCardRepository>();
        _vaccineRepositoryMock = new Mock<IVaccineRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _handler = new VaccineCardHandler(
            _repositoryMock.Object,
            _vaccineRepositoryMock.Object,
            _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_ReturnsFailure_WhenVaccineCardNotFound()
    {
        var request = new VaccineCardCommand(
            new Guid("d1e00815-0b05-461e-90cf-f2a6bd53987e"),
            new Guid("4af89a56-64cb-4b26-81c6-3c7cd6d614f9"));

        _repositoryMock.Setup(r => r.GetByIdCard(request.CardId))
            .ReturnsAsync((VaccineCard)null);  // Simula cartão não encontrado

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Error);
        
    }

    [Fact]
    public async Task Handle_ReturnsFailure_WhenVaccineNotFound()
    {
        var request = new VaccineCardCommand(
            new Guid("d1e00815-0b05-461e-90cf-f2a6bd53987e"),
            new Guid("4af89a56-64cb-4b26-81c6-3c7cd6d614f9"));
        var existingCard = VaccineCard.Create(new Guid("d1e00815-0b05-461e-90cf-f2a6bd53987e"),"João", "746904160870001","30136198058"); 

        _repositoryMock.Setup(r => r.GetByIdCard(request.CardId))
            .ReturnsAsync(existingCard);

        _vaccineRepositoryMock.Setup(v => v.VaccineExistAsyncById(request.VaccineId))
            .ReturnsAsync((Vaccine)null);  // Simula vacina não encontrada

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Error);
        
    }

    [Fact]
    public async Task Handle_ReturnsSuccess_WhenVaccineAddedSuccessfully()
    {
        var request = new VaccineCardCommand(
        new Guid("d1e00815-0b05-461e-90cf-f2a6bd53987e"),
        new Guid("4af89a56-64cb-4b26-81c6-3c7cd6d614f9"));
        var existingCard = VaccineCard.Create(new Guid("d1e00815-0b05-461e-90cf-f2a6bd53987e"),"João", "746904160870001","30136198058"); 
        var existingVaccine =  Vaccine.Create("BCG", "Fábrica X", VaccineCategory.Adult, VaccineDose.First, 0,true,  "Vac-1");

        _repositoryMock.Setup(r => r.GetByIdCard(request.CardId))
            .ReturnsAsync(existingCard);

        _vaccineRepositoryMock.Setup(v => v.VaccineExistAsyncById(request.VaccineId))
            .ReturnsAsync(existingVaccine);

        _repositoryMock.Setup(r => r.UpdateAsync(existingCard))
            .Verifiable();

        _unitOfWorkMock.Setup(u => u.CommitAsync())
            .Returns(Task.CompletedTask);

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal("João", result.Value.Name);
        Assert.Equal(existingVaccine.VacciName, result.Value.Name);

        _repositoryMock.Verify(r => r.UpdateAsync(existingCard), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
    }

    [Fact]
    public async Task Handle_ReturnsFailure_OnException()
    {
        var request = new VaccineCardCommand(
            new Guid("d1e00815-0b05-461e-90cf-f2a6bd53987e"),
            new Guid("4af89a56-64cb-4b26-81c6-3c7cd6d614f9"));
        var existingCard = VaccineCard.Create(new Guid("d1e00815-0b05-461e-90cf-f2a6bd53987e"),"João", "746904160870001","30136198058"); 
        var existingVaccine =  Vaccine.Create("BCG", "Fábrica X", VaccineCategory.Adult, VaccineDose.First, 0,true,  "Vac-1");

        _repositoryMock.Setup(r => r.GetByIdCard(request.CardId))
            .ReturnsAsync(existingCard);

        _vaccineRepositoryMock.Setup(v => v.VaccineExistAsyncById(request.VaccineId))
            .ReturnsAsync(existingVaccine);

        _repositoryMock.Setup(r => r.UpdateAsync(existingCard))
            .Throws(new Exception("Erro inesperado"));

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Error);
        
    }
}