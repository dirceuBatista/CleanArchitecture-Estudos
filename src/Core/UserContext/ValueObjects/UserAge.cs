using System.Text.Json.Serialization;
using Core.SharedContext.ValueObjects;
using Core.UserContext.Errors;
using Core.UserContext.Errors.Exceptions;

namespace Core.UserContext.ValueObjects;

public sealed record UserAge : ValueObject
{
    public int Number { get; }

    #region Constants

    public const int MinLength = 0;
    public const int MaxLength = 100;

    #endregion

    #region Constructors

    private UserAge()
    {
        
    }
    [JsonConstructor]
    private UserAge(int age)
    {
        Number = age;
    }

    #endregion

    #region Factory

    public static UserAge Create(int age)
    {
        Validator(age);
        return new UserAge(age);
    }

    #endregion

    #region Methods

    public static void Validator(int age)
    {
        if (age < MinLength || age > MaxLength)
            throw new AgeInvalidLengthException(ErrorMessage.Age.InvalidLength);
    }

    #endregion
}