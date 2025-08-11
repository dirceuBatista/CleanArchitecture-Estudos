namespace Core.VaccineContext.Errors;

public class ErrorMessageVaccine
{
    public static  NameErrorMessage VaccineName { get; }
    public static ManufacturerErrorMessage Manufacturer { get;  }
    
    public static VaccineCategoryErrorMessage VaccineCategory { get;  }
    public static VaccineDoseErrorMessage VaccineDose { get;  }
    public class NameErrorMessage
    {
        public string Invalid { get; set; } = "O Nome informado é inválido.";
        public string InvalidNullOrEmpty { get; set; } = "O Nome informado não pode ser vazio ou nulo.";
        public string InvalidLength { get; set; } = "O Nome deve conter pelo menos 5 dígitos.";
    }
    public class ManufacturerErrorMessage
    {
        public string Invalid { get; set; } = "O Nome informado é inválido.";
        public string InvalidNullOrEmpty { get; set; } = "O Nome informado não pode ser vazio ou nulo.";
    }
    public class VaccineCategoryErrorMessage
    {
        public string Invalid { get; set; } = "O campo deve receber old,kid ou adult";
        public string InvalidNullOrEmpty { get; set; } = "O campo informado não pode ser vazio ou nulo.";
    }
    public class VaccineDoseErrorMessage
    {
        public string Invalid { get; set; } = "O campo deve receber first, second, third ou Reinforcement";
        public string InvalidNullOrEmpty { get; set; } = "O campo informado não pode ser vazio ou nulo.";
    }

}