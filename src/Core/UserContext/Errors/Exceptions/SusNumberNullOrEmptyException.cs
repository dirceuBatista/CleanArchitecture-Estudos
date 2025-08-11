using Core.SharedContext.Exceptions;

namespace Core.UserContext.Errors.Exceptions;

public class SusNumberNullOrEmptyException(string message) : DomainException(message);

    
