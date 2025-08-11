using Core.SharedContext.Common;
using Core.UserContext.Errors;
using Core.UserContext.Errors.Exceptions;
using Core.UserContext.ValueObjects;
using FluentAssertions;

namespace Core.test.UserContext.ValueObjects;

public class UserEmailTest
{
    [Fact]
    public void Should_Create_Valid_Email()
    {
       
        var emailValue = "dirceu@example.com";
        
        var email = UserEmail.Create(emailValue);

        Assert.Equal(emailValue, email.Address);
        Assert.Equal(emailValue.ToLower().ToBase64(), email.Hash);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Should_Throw_When_Email_Is_Empty(string invalidEmail)
    {
        var exception = Assert.Throws<EmailNullOrEmptyException>(() => UserEmail.Create(invalidEmail));

        Assert.Equal(ErrorMessage.Email.InvalidNullOrEmpty, exception.Message);
    }

    [Theory]
    [InlineData("invalid-email")]
    [InlineData("dirceu@")]
    [InlineData("@example.com")]
    [InlineData("dirceu@example")]
    public void Should_Throw_When_Email_Has_Invalid_Format(string invalidEmail)
    {
       
        var exception = Assert.Throws<EmailInvalidException>(() => UserEmail.Create(invalidEmail));
        Assert.Equal(ErrorMessage.Email.Invalid, exception.Message);
    }
}