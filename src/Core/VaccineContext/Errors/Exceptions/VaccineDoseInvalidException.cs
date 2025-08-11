using Core.SharedContext.Exceptions;

namespace Core.VaccineContext.Errors.Exceptions;

public class VaccineDoseInvalidException(string message) : DomainException(message);

    
