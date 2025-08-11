using Core.UserContext.Errors.Exceptions;
using Core.UserContext.ValueObjects;
using FluentAssertions;

namespace Core.test.UserContext.ValueObjects;

public class UserCpfTest
{
    [Fact]
    public void Should_Create_Valid_Cpf()
    {
        var cpf = UserCpf.Create("814.848.260-86");
        var equals = cpf.NumberCpf.Should().Be("81484826086");
    }
    [Fact]
    public void Should_Throw_When_Cpf_Is_Null_Or_Empty()
    {
        string input = "";
        Assert.Throws<CpfNullOrEmptyException>(() => UserCpf.Create(input));
    }
    [Fact]
    public void Should_Throw_When_Cpf_Length_Is_Invalid()
    {
        string input = "1456";
        Assert.Throws<CpfInvalidException>(() => UserCpf.Create(input));
    }
    [Fact]
    public void Should_Throw_When_Cpf_All_Digits_Are_Equal()
    {
        string input = "00000000000";
        Assert.Throws<CpfInvalidException>(() => UserCpf.Create(input));
    }
    [Fact]
    public void Should_Throw_When_Cpf_Has_Invalid_Digits()
    {
        string input = "158.2&$.245-76";
        Assert.Throws<CpfInvalidException>(() => UserCpf.Create(input));
    }
    [Fact]
    public void Should_Convert_From_String_To_UserCpf()
    { 
        var cpf = UserCpf.Create("814.848.260-86");
        Assert.Equal("81484826086" , cpf.ToString());
        
    }

    [Fact]
    public void Should_Convert_From_UserCpf_To_String()
    {
        var cpf = UserCpf.Create("814.848.260-86");
        string test = cpf;
        Assert.Equal("81484826086" , test);
    }


    



 
}