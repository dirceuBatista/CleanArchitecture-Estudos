
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Core.SharedContext.Entities;
using Core.UserContext.Entities;


namespace Core.VaccineCardContext.Entities;

public class VaccineCard : Entity
{
    public string UserName { get; set; }
    public string UserSusNumber { get; set; }
    public string UserCpf { get; set; }
    public Guid UserId { get; set; }
    [JsonIgnore]
    public User user { get; set; }
    public string VaccineNamesSerialized { get; set; }
    private List<string> _vaccineNameCache;

    [NotMapped]
    public List<string> VaccineName
    {
        get
        {
            if (_vaccineNameCache == null)
                _vaccineNameCache = VaccineNamesSerialized?.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList() ?? new List<string>();
            return _vaccineNameCache;
        }
        set
        {
            _vaccineNameCache = value;
            VaccineNamesSerialized = string.Join(',', value);
        }
    }

    public void AddVaccineName(string name)
    {
        var list = VaccineName;
        list.Add(name);
        VaccineName = list; 
    }

    #region Constructors

    private VaccineCard() : base(Guid.NewGuid())
    {
        
    }
    private VaccineCard(Guid userId ,string userName, string userSusNumber, string userCpf) : base(Guid.NewGuid())
    {

        UserId = userId;
        UserName = userName;
        UserSusNumber = userSusNumber;
        UserCpf = userCpf;
        
    }

    #endregion

    #region Factory

    public static VaccineCard Create(Guid userId,string name, string userSusNumber, string userCpf)
    {
        return new VaccineCard(userId,name, userSusNumber, userCpf);
    }

    #endregion  

  
   
}