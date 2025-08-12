using Core.SharedContext.Entities;
using Core.UserContext.ValueObjects;
using Core.VaccineCardContext.Entities;

namespace Core.UserContext.Entities;

public class User : Entity
{
    public UserName Name { get;  } 
    public UserEmail Email { get;  } 
    public string PasswordHash { get; } 
    public UserAge Age { get; } 
    public UserAllergy? Allergy { get; } 
    public UserGender Gender { get; } 
    public UserCpf Cpf{ get; } 
    public UserSusNumber? SusNumber { get; } 
    public VaccineCard  Card { get; private set; }
    

    #region Constructor

    private User() : base(Guid.NewGuid())
    {
        
    }
    private User(UserName name, UserEmail email,string password, UserAge age, UserAllergy? allergy, UserGender gender,UserCpf cpf, UserSusNumber? susNumber) : base(Guid.NewGuid())
    {
        Name = name;
        Email = email;
        PasswordHash = password;
        Age = age;
        Allergy = allergy;
        Gender = gender;
        Cpf = cpf;
        SusNumber = susNumber;
        Card = VaccineCard.Create( Id ,name ,susNumber,cpf);
    }

    #endregion

    #region Factory

    public static User Create
    (UserName name, UserEmail email,
        string password,UserAge age, UserAllergy? allergy, UserGender gender, UserCpf cpf, UserSusNumber? susNumber)
    {
        return new User(name, email, password , age, allergy, gender, cpf, susNumber);
    }

    #endregion
    
}