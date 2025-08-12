using System.Text.Json.Serialization;
using Core.SharedContext.ValueObjects;

using Core.VaccineContext.Errors;
using Core.VaccineContext.Errors.Exceptions;

namespace Core.VaccineContext.ValueObjects;

public sealed record VaccineName : ValueObject
{

    public string Name { get; } 
    

    #region Constants

    private const short MinLength = 3;
    private const short MaxLength = 50;

    #endregion

    #region Constructors

    private VaccineName()
    {
        
    }
    [JsonConstructor]
    private VaccineName( string name)
    {
        Name = name;
    }

    #endregion

    #region Factory

    public static VaccineName Create(string name)
    {
        name = name.Trim();
        Validate(name);
        return new VaccineName(name);
    }

    #endregion

    #region Methods

    private static void Validate(string name)
    {
        
        if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            throw new VaccineNameNullOrEmptyException(ErrorMessageVaccine.VaccineName.InvalidNullOrEmpty);
        if (name.Length < MinLength || name.Length > MaxLength)
            throw new VaccineNameNullOrEmptyException(ErrorMessageVaccine.VaccineName.InvalidLength);

    }

    #endregion

    #region Operators
    public static implicit operator VaccineName(string name)
        =>new VaccineName(name);
    public static implicit operator string(VaccineName name)
        =>name.ToString();
    

    #endregion

    #region Overrides

    public override string ToString()
        => $"{Name}".Trim();


    #endregion
};