using Application.SharedContext.Repositories.Abstractions;
using Application.UserContext.Repositories.Abstractions;
using Application.UserContext.UseCases.CreateUser;
using Core.UserContext.Entities;
using Core.UserContext.Errors.Exceptions;
using Moq;

namespace Application.Test.UserContext.UseCases.Create;

public class CreateUserHandlerTest
{
    private readonly Mock<IUserRepository> _repositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly UserHandler _handler;

    public CreateUserHandlerTest()
    {
        _repositoryMock = new Mock<IUserRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _handler = new UserHandler(_repositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task Handle_ReturnsFailure_WhenEmailAlreadyExists()
    {
        
        var command = new UserCommand(
            "João","Silva","novo@email.com","senha123", 30,null,'M',"12345678900","123456789012345");
        
        _repositoryMock.Setup(r => r.EmailExistAsync(command.Email))
            .ReturnsAsync(true);

        var exception = await Assert.ThrowsAsync<EmailInvalidException>(() =>
            _handler.Handle(command, CancellationToken.None));

        Assert.Contains("Email já está cadastrado", exception.Message);
    }

    [Fact]
    public async Task Handle_ReturnsSuccess_WhenUserCreated()
    {
      
        var command = new UserCommand(
            "João","Silva","novo@email.com","senha123", 30,null,'M',"12345678900","123456789012345");
        
        
        _repositoryMock.Setup(r => r.EmailExistAsync(command.Email))
            .ReturnsAsync(false);

        _repositoryMock.Setup(r => r.SaveAsync(It.IsAny<User>()))
            .Returns(Task.CompletedTask);

        _unitOfWorkMock.Setup(u => u.CommitAsync())
            .Returns(Task.CompletedTask);

       
        var result = await _handler.Handle(command, CancellationToken.None);

        
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal("João Silva", result.Value.Name.ToString());
        _repositoryMock.Verify(r => r.SaveAsync(It.IsAny<User>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
    }

    [Fact]
    public async Task Handle_ReturnsFailure_OnException()
    {
        
        var command = new UserCommand("João","Silva","novo@email.com","senha123", 30,null,'M',"12345678900","123456789012345");

        
        _repositoryMock.Setup(r => r.EmailExistAsync(command.Email))
            .ReturnsAsync(false);

        _repositoryMock.Setup(r => r.SaveAsync(It.IsAny<User>()))
            .ThrowsAsync(new Exception("Erro inesperado"));

        var ex = await Assert.ThrowsAsync<Exception>(() =>
            _handler.Handle(command, CancellationToken.None));

        Assert.Contains("Erro interno no servidor", ex.Message);
    }


}

