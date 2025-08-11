using Core.SharedContext.Exceptions;

namespace Core.UserContext.Errors.Exceptions;

public class NameNullOrEmptyException(string message) : DomainException(message);

    
