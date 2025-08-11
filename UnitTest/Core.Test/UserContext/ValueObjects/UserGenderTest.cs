

using Core.UserContext.Errors.Exceptions;
using Core.UserContext.ValueObjects;
using FluentAssertions;

namespace Core.test.UserContext.ValueObjects;

public class UserGenderTest
{
    [Fact]
    public void Should_Create_UserGender_Masculino_When_Char_Is_M()
    {
        var Gender = UserGender.Create('m');
        Gender.Value.Should().Be("Masculino");
    }

    [Fact]
    public void Should_Create_UserGender_Feminino_When_Char_Is_F()
    {
        var Gender = UserGender.Create('f');
        Gender.Value.Should().Be("Feminino");
    }

    [Fact]
    public void Should_Throw_When_Char_Is_WhiteSpace()
    {
         char input = ' ';
         Assert.Throws<GenderInvalidException>(() => UserGender.Create(input));
    
    }
    [Fact]
    public void Should_Throw_When_Char_Is_Invalid()
    {
        char input = 'j';
        Assert.Throws<GenderInvalidException>(() => UserGender.Create(input));
    }
};