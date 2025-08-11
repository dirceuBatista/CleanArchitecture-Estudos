using Core.SharedContext.Exceptions;

namespace Core.VaccineContext.Errors.Exceptions;

public class VaccineNameNullOrEmptyException(string message) : DomainException(message);

    
