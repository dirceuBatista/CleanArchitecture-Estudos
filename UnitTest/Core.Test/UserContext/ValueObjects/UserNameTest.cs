
using Core.UserContext.Errors.Exceptions;
using Core.UserContext.ValueObjects;
using FluentAssertions;


namespace Core.test.UserContext.ValueObjects;

public class UserNameTest
{ 
    
    private const string FirstName = "dirceu";
    private const string LastName = "batista";
    
    [Fact]
    public void should_Return_Fail_FirstName_Length()
    {
        var firstName = "D";
        var invalidLastName = " batman";
        var exception = Assert.Throws<NameNullOrEmptyException>(() => UserName.Create(firstName, invalidLastName));
    }
    [Fact]
    public void should_Return_Fail_LastName_Length()
    {
        var firstName = "Diego";
        var invalidLastName = " b ";
        var exception = Assert.Throws<NameNullOrEmptyException>(() => UserName.Create(firstName, invalidLastName));
    }
    [Fact]
    public void should_Return_Correct_FirstName( )
    {
        
        var userName = UserName.Create(FirstName, LastName);
        userName.FirstName.Should().Be(FirstName);
    }

    [Fact]
    public void should_Return_Correct_LastName()
    {
        var userName = UserName.Create(FirstName, LastName);
        userName.LastName.Should().Be(LastName);
    }
    [Fact]
    public void should_Throw_When_FirstName_Is_Empty()
    {
       
        var firstName = "";
        var invalidLastName = " batman";
        var exception = Assert.Throws<NameNullOrEmptyException>(() => UserName.Create(firstName, invalidLastName));
    } 
   
    [Fact]
   
    public void should_Throw_When_LastName_Is_Empty()
    {
        var firstName = "dirceu";
        var invalidLastName = " ";
        var exception = Assert.Throws<NameNullOrEmptyException>(() => UserName.Create(firstName, invalidLastName));
    }
    [Fact]
    public void ShouldOverrideToStringMethod()
    {
        var name = UserName.Create("Dirceu", " batista");
        Assert.Equal("Dirceu batista" , name.ToString());
    }
    [Fact]
    public void ShouldConvertToStringMethod()
    {
        var name = UserName.Create("Dirceu", " batista");
        string test = name;
        Assert.Equal("Dirceu batista" , test);
    }

}