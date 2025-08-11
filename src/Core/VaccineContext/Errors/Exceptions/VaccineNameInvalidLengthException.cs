using Core.SharedContext.Exceptions;

namespace Core.VaccineContext.Errors.Exceptions;

public class VaccineNameInvalidLengthException(string message) : DomainException(message);

    
