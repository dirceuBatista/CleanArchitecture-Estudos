using Core.SharedContext.Exceptions;

namespace Core.UserContext.Errors.Exceptions;

public class AgeInvalidLengthException(string message) : DomainException(message);

    
