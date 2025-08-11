namespace Core.test.UserContext.ValueObjects;

public class UserSusNumber
{
    [Fact]
    public void Should_Create_Valid_Sus_Number()
    {
        Assert.Fail();
    }
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Should_Throw_When_Sus_Is_Null_Or_Empty(string input)
    {
        Assert.Fail();
    }
    [Theory]
    [InlineData("1234567890")]
    [InlineData("1234567890123456")]
    public void Should_Throw_When_Sus_Length_Is_Invalid(string input)
    {
        Assert.Fail();
    }
    [Fact]
    public void Should_Throw_When_First_Digit_Is_Invalid()
    {
        Assert.Fail();
    }
    [Fact]
    public void Should_Throw_When_Sum_Validation_Fails()
    {
        Assert.Fail();
    }
    [Fact]
    public void Should_Convert_From_String_To_UserSusNumber()
    {
       Assert.Fail();
    }






}