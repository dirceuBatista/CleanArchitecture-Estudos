using System.Text.Json.Serialization;
using Core.SharedContext.ValueObjects;
using Core.UserContext.Errors;
using Core.UserContext.Errors.Exceptions;

namespace Core.UserContext.ValueObjects;

public sealed record UserAllergy : ValueObject
{
    public bool Value { get; set; }
    public string? Description { get; set; }

    #region Constants

    public const int Maxlength = 200;

    #endregion
    #region Constructors

    public UserAllergy()
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

    public static UserAllergy Create(bool value , string description)
    {
        if (description.Length > Maxlength)
            throw new AllergyLengthException(ErrorMessage.Allergy.InvalidLength);
        
                
        return new UserAllergy(value, description);
    }

    #endregion

   
}