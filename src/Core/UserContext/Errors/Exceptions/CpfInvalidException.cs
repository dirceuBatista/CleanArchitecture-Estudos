using Core.SharedContext.Exceptions;

namespace Core.UserContext.Errors.Exceptions;

public class CpfInvalidException(string message) : DomainException(message);

    
