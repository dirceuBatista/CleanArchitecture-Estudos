using System.Text.Json.Serialization;
using Core.SharedContext.Common;
using Core.SharedContext.ValueObjects;
using Core.UserContext.Errors;
using Core.UserContext.Errors.Exceptions;

namespace Core.UserContext.ValueObjects;

public sealed record UserSusNumber : ValueObject
{
    public string NumberSus { get; private set; }

    #region Constants

    public const short Length = 15;

    #endregion

    #region Constructors

    private UserSusNumber()
    {
       
    }
    [JsonConstructor]
    private UserSusNumber(string numberSus)
    {
        NumberSus = numberSus;
    }

    #endregion

    #region Factory

    public static UserSusNumber Create(string numberSus)
    {
        numberSus = numberSus.ToNumbers();
        Validator(numberSus);
        return new UserSusNumber(numberSus);
    }

    #endregion

    #region Methods

        public static bool Validator(string number)
        {
            if (string.IsNullOrEmpty(number) || string.IsNullOrWhiteSpace(number))
                throw new SusNumberNullOrEmptyException(ErrorMessage.SusNumber.InvalidNullOrEmpty);
            if (number.Length != Length)
                throw new SusNumberInvalidLengthException(ErrorMessage.SusNumber.InvalidLength);
            
            number = new string(number.Where(char.IsDigit).ToArray());

            char firstDigit = number[0];
            if (firstDigit != '1' && firstDigit != '2' && firstDigit != '3' &&
                firstDigit != '7' && firstDigit != '8' && firstDigit != '9')
                throw new SusNumberInvalidException(ErrorMessage.SusNumber.Invalid);

            long sum = 0;
            for (int i = 0; i < 15; i++)
            {
                int digit = int.Parse(number[i].ToString());
                sum += digit * (15 - i);
            }

            if (sum % 11 != 0)
                throw new SusNumberInvalidException(ErrorMessage.SusNumber.Invalid);

            return true; 
        }

    #endregion

    #region Operators

    public static implicit operator UserSusNumber(string susNumber)
    {
        return Create(susNumber);
    }
    public static implicit operator string (UserSusNumber number)
    {
        return number?.NumberSus;
    }
    #endregion

    #region Override

    public override string ToString()
    {
        return NumberSus;
    }

    #endregion
}