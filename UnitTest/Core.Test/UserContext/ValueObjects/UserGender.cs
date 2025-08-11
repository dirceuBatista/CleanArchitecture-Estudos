using System.Text.Json.Serialization;
using Core.SharedContext.ValueObjects;

namespace Core.test.UserContext.ValueObjects;

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
            throw new InvalidGenderException(ErrorMessages.Gender.InvalidNullOrEmpty);
        
        switch (char.ToUpper(value))
        {
            case 'M': return "Masculino";
            case 'F': return "Feminino";
            default: throw new InvalidGenderException(ErrorMessages.Gender.InvalidLength);
        }
        
        
    }

    #endregion

    #region Overrides

    public override string ToString()
    {
        return Value;
    }

    #endregion
}