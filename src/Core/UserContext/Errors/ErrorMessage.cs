namespace Core.UserContext.Errors;

public class ErrorMessage
{
    public static NameErrorMessages Name { get; } = new();
    public static EmailErrorMessages Email { get; } = new();
    public static AgeErrorMessages Age { get; } = new();
    public static AllergyErrorMessages Allergy { get; } = new();
    public static GenderErrorMessages Gender { get; } = new();
    public static CpfErrorMessages Cpf { get; } = new();
    public static SusNumberErrorMessages SusNumber { get; } = new();
    
    #region ErrorMessage

    public class NameErrorMessages
    { 
        public string Invalid { get; set; } = "O Nome informado é inválido.";
        public string InvalidNullOrEmpty { get; set; } = "O Nome informado não pode ser vazio ou nulo.";
        public string InvalidLength { get; set; } = "O Nome deve conter pelo menos 2 dígitos.";
        
        public string InvalidLetters { get; set; } = "O Nome informado é inválido devido ao padrão de caracteres.";
    }
    public class EmailErrorMessages
    { 
        public string Invalid { get; set; } = "O Email informado é inválido.";
        public string InvalidNullOrEmpty { get; set; } = "O Email informado não pode ser vazio ou nulo.";
        public string InvalidLength { get; set; } = "O Email deve conter pelo menos 2 dígitos.";
    }
    public class AgeErrorMessages
    { 
        public string Invalid { get; set; } = "A idade informada é inválido.";
        public string InvalidNullOrEmpty { get; set; } = "A idade informada não pode ser vazia ou nula.";
        public string InvalidLength { get; set; } = "A Idade deve Ser entre 0 e 100 .";
    }
    public class AllergyErrorMessages
    {
        public string InvalidLength { get; set; } = "A Descrição deve Ser entre 0 e 200 Caracteres .";
    }
    public class GenderErrorMessages
    {
        public string Invalid { get; set; } = "O genero informado é inválido.";
        public string InvalidNullOrEmpty { get; set; } = "O genero informado não pode ser vazio ou nulo.";

        public string InvalidLength { get; set; } =
            "O genero deve conter A letra M Para masculino ou a letra F para feminino.";

    }
    public class CpfErrorMessages
    {
        public string Invalid { get; set; } = "O CPF informado é inválido.";
        public string InvalidNullOrEmpty { get; set; } = "O CPF informado não pode ser vazio ou nulo.";

        public string InvalidLength { get; set; } =
            "O Cpf de conter 11 digitos.";

    }
    public class SusNumberErrorMessages
    {
        public string Invalid { get; set; } = "O Numero Sus informado é inválido.";
        public string InvalidNullOrEmpty { get; set; } = "O Campo Sus informado não pode ser vazio ou nulo.";
        public string InvalidLength { get; set; } = "O Numero Sus deve conter 15 dígitos.";
        
    }




    #endregion
}