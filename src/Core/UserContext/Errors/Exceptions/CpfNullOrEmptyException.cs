using Core.SharedContext.Exceptions;

namespace Core.UserContext.Errors.Exceptions;

public class CpfNullOrEmptyException(string message) : DomainException(message);

    
