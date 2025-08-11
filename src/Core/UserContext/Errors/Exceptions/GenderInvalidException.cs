using Core.SharedContext.Exceptions;

namespace Core.UserContext.Errors.Exceptions;

public class GenderInvalidException(string message) : DomainException(message);

    
