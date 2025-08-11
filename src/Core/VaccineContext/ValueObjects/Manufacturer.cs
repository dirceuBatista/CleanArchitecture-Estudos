using System.Text.Json.Serialization;
using Core.SharedContext.ValueObjects;

namespace Core.VaccineContext.ValueObjects;

public sealed record Manufacturer : ValueObject
{
    public string Enterprise { get; }

    #region Constructors

   
    private Manufacturer()
    {
        
    }
    [JsonConstructor]
    private Manufacturer(string enterprise)
    {
        Enterprise = enterprise;
    }

    #endregion

    #region Factory

    public static Manufacturer Create(string enterprise)
    {
        return new Manufacturer(enterprise);
    }

    #endregion
    
    #region Operators

    public static implicit operator string(Manufacturer manufacturer)
        => manufacturer.ToString();

    #endregion

    #region Overrides

    public override string ToString() => $"{Enterprise}".Trim();

    #endregion
}