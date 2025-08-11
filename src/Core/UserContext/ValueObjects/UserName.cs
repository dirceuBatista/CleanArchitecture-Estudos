using System.Text.Json.Serialization;
using Core.SharedContext.ValueObjects;
using Core.UserContext.Errors;
using Core.UserContext.Errors.Exceptions;

namespace Core.UserContext.ValueObjects;

public record UserName : ValueObject
{
    public string FirstName { get; } 
    public string LastName { get;  } 

    #region Constants

    private const short MinLength = 3;
    private const short MaxLength = 40;

    #endregion

    #region Constructors

    private UserName()
    {
        
    }
    [JsonConstructor]
    private UserName(string firstName, string lastName) 
    {
        FirstName = firstName;
        LastName = lastName;
    }

    #endregion

    #region Factory

    public static UserName Create(string firstName, string lastName)
    {
        firstName = firstName.Trim();
        lastName = lastName.Trim();
        Validate(firstName,lastName);
        return new UserName(firstName, lastName);


    }

    #endregion

    #region Methods

    private static void Validate(string firstName, string lastName)
    {
        
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            throw new NameNullOrEmptyException(ErrorMessage.Name.InvalidNullOrEmpty);
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            throw new NameNullOrEmptyException(ErrorMessage.Name.Invalid);
        if (firstName.Length < MinLength || firstName.Length > MaxLength)
            throw new NameNullOrEmptyException(ErrorMessage.Name.InvalidLength);
        if (lastName.Length < MinLength || lastName.Length > MaxLength)
            throw new NameNullOrEmptyException(ErrorMessage.Name.InvalidLength);

       

    }

    #endregion

    #region Operators

    public static implicit operator string(UserName name)
        =>name.ToString();
    
 

    #endregion

    #region Overrides

    public override string ToString()
        => $"{FirstName.Trim()} {LastName.Trim()}".Trim();
    

    #endregion
};