using Core.SharedContext.Exceptions;

namespace Core.VaccineContext.Errors.Exceptions;

public class ManufactureInvalidException(string message) : DomainException(message);

    
