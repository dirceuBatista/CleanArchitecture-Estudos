using System.Text.Json.Serialization;
using Core.SharedContext.Common;
using Core.SharedContext.ValueObjects;
using Core.UserContext.Errors;
using Core.UserContext.Errors.Exceptions;

namespace Core.UserContext.ValueObjects;

public sealed record UserCpf : ValueObject
{
     public string NumberCpf { get; }

    #region Constants

    public const short Length = 11;

    #endregion

    #region Constructors

    private UserCpf()
    {
        
    }
    [JsonConstructor]
    private UserCpf(string numberCpf)
    {
        NumberCpf = numberCpf;
    }

    #endregion

    #region Factory
    
    public static UserCpf Create(string numberCpf)
    {
        numberCpf = numberCpf.ToNumbers();
        Validate(numberCpf);
        return new UserCpf(numberCpf);

    }

    #endregion

    #region Methods

    private static void Validate(string numberCpf)
    {
        if (string.IsNullOrEmpty(numberCpf)|| string.IsNullOrWhiteSpace(numberCpf))
            throw new CpfNullOrEmptyException(ErrorMessage.Cpf.InvalidNullOrEmpty);
        if (numberCpf.Length != Length)
            throw new CpfInvalidException(ErrorMessage.Cpf.InvalidLength);
        if (numberCpf.All(c => c == numberCpf[0]))
            throw new CpfInvalidException(ErrorMessage.Cpf.Invalid);

        var firstMultiplier = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var secondMultiplier = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        var temp = numberCpf[..9];
        var sum = 0;

        for (var i = 0; i < 9; i++)
            sum += int.Parse(temp[i].ToString()) * firstMultiplier[i];

        var rest = sum % 11;
        rest = rest < 2 ? 0 : 11 - rest;

        var digit = rest.ToString();
        temp += digit;
        sum = 0;

        for (var i = 0; i < 10; i++)
            sum += int.Parse(temp[i].ToString()) * secondMultiplier[i];

        rest = sum % 11;
        rest = rest < 2 ? 0 : 11 - rest;
        digit += rest;

        if (!numberCpf.EndsWith(digit))
            throw new CpfInvalidException(ErrorMessage.Cpf.Invalid);
    }
    

    #endregion

    #region Operators

    public static implicit operator UserCpf (string numberCpf)
    {
        return Create(numberCpf);
    }
    public static implicit operator string (UserCpf cpf)
    {
        return cpf.NumberCpf;
    }
    #endregion

    #region Overrides

    public override string ToString()
    {
        return NumberCpf;
    }

    #endregion
}

