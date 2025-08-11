using Core.SharedContext.Exceptions;

namespace Core.UserContext.Errors.Exceptions;

public class EmailNullOrEmptyException(string message) : DomainException(message);

    
