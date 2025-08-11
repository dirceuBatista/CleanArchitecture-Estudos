using Core.SharedContext.Exceptions;

namespace Core.UserContext.Errors.Exceptions;

public class SusNumberInvalidException(string message) : DomainException(message);

    
