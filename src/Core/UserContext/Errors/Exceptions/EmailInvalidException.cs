using Core.SharedContext.Exceptions;

namespace Core.UserContext.Errors.Exceptions;

public class EmailInvalidException(string message) : DomainException(message);

    
