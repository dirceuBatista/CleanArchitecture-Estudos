using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Core.SharedContext.Common;
using Core.SharedContext.ValueObjects;
using Core.UserContext.Errors;
using Core.UserContext.Errors.Exceptions;

namespace Core.UserContext.ValueObjects;

public sealed partial record UserEmail : ValueObject
{
    public string Address { get; } = string.Empty;
    public string? Hash { get; } = string.Empty;
    
    #region Constants

    private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
    

    #endregion

    #region Constructors

    public UserEmail()
    {
        
    }
   [JsonConstructor]
    private UserEmail(string address, string hash)
    {
        Address = address;
        Hash = hash;
    }

    #endregion

    #region Factory

    public static UserEmail Create(string address)
    {
        if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address))
            throw new EmailNullOrEmptyException(ErrorMessage.Email.InvalidNullOrEmpty);
        
        address = address.Trim();
        address = address.ToLower();
        
        if (!EmailRegex().IsMatch(address))
            throw new EmailInvalidException(ErrorMessage.Email.Invalid);

        return new UserEmail(address, address.ToBase64());
    }

   
    #endregion

    #region Operators

    public static implicit operator string (UserEmail email )
    {
        return email.ToString();
    }
    #endregion

    #region Overrides

    public override string ToString()
    {
        return Address;
    }

    #endregion
    
    #region Other

    [GeneratedRegex(Pattern)]
    private static partial Regex EmailRegex();

    #endregion

    
}


