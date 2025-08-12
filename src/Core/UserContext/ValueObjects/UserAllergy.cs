using System.Text.Json.Serialization;
using Core.SharedContext.ValueObjects;
using Core.UserContext.Errors;
using Core.UserContext.Errors.Exceptions;

namespace Core.UserContext.ValueObjects;

public sealed record UserAllergy : ValueObject
{
    public bool Value { get; private set; }
    public string? Description { get;  }

    #region Constants

    public const int Maxlength = 200;

    #endregion
    
    #region Constructors

    private UserAllergy()
    {
        
    }
    [JsonConstructor]
    private UserAllergy(bool value, string description) 
    {
        Value = value;
        Description = description;
    }

    #endregion

    #region Factory

    public static UserAllergy Create(string? description)
    {
        if (string.IsNullOrWhiteSpace(description))
            return new UserAllergy(false, string.Empty);
        
        Validator(description);
        
        return new UserAllergy(true, description);
    }

    #endregion

    #region Methods

    private static void Validator(string? description)
    {
        if (description?.Length > Maxlength)
            throw new AllergyLengthException(ErrorMessage.Allergy.InvalidLength);
    }

    #endregion
    
    #region Operators

    public static implicit operator UserAllergy(string description)
    {
        return  UserAllergy.Create(description);
    }
    public static implicit operator string (UserAllergy allergy)
    {
        return allergy.ToString();
    }
    #endregion

    #region Overrides

    public override string ToString()
    {
        return  Description?? string.Empty;;
    }

    #endregion
   
}