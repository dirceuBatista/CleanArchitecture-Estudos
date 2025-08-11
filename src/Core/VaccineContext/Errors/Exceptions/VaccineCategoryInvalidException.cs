using Core.SharedContext.Exceptions;

namespace Core.VaccineContext.Errors.Exceptions;

public class VaccineCategoryInvalidException(string message) : DomainException(message);

    
