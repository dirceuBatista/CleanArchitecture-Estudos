using System.Text.Json.Serialization;
using Core.SharedContext.ValueObjects;
using Core.UserContext.Errors;
using Core.UserContext.Errors.Exceptions;

namespace Core.UserContext.ValueObjects;

public sealed record UserGender : ValueObject
{
    public string Value { get; }

    #region Constante

    private const string Masculino = "Masculino";
    private const string Feminino = "Feminino";
    

    #endregion

    #region Constructor

    private UserGender()
    {
        
    }
    [JsonConstructor]
    private UserGender(string value)
    {
        Value = value;
    }

    #endregion

    #region Factory

    public static UserGender Create(char value)
    {
        var gender = Validator(value);
        return new UserGender(gender);
    }

    #endregion

    #region Methods

    private static string Validator(char value)
    {
        if (char.IsWhiteSpace(value))
            throw new GenderInvalidException(ErrorMessage.Gender.InvalidNullOrEmpty);
        
        switch (char.ToUpper(value))
        {
            case 'M': return "Masculino";
            case 'F': return "Feminino";
            default: throw new GenderInvalidException(ErrorMessage.Gender.InvalidLength);
        }
        
        
    }

    #endregion
    #region Operators

    public static implicit operator string(UserGender gender)
        =>gender.ToString();
    public static implicit operator UserGender(char gender)
    {
        return Create(gender);
    }

    #endregion

    #region Overrides

    public override string ToString()
    {
        return Value;
    }

    #endregion
}



