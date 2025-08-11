using Core.SharedContext.Exceptions;

namespace Core.UserContext.Errors.Exceptions;

public class SusNumberInvalidLengthException(string message) : DomainException(message);

    
