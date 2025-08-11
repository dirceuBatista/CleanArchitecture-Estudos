using Core.UserContext.Errors.Exceptions;
using Core.UserContext.ValueObjects;
using FluentAssertions;

namespace Core.test.UserContext.ValueObjects;

public class UserAgeTest
{
    [Fact]
    public void Should_Throw_For_Invalid_Age_Ranges()
    {
        int invalidAge = 150;
        Assert.Throws<AgeInvalidLengthException>(() => UserAge.Create(invalidAge));
    }
    [Fact]
    public void Should_Create_UserAge_When_Validmin()
    {
        var Age = UserAge.Create(0);
        Age.Number.Should().Be(0);
    }
    [Fact]
    public void Should_Create_UserAge_When_ValidMax()
    {
        var Age = UserAge.Create(100);
        Age.Number.Should().Be(100);
    }



}