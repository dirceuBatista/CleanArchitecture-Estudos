using System.Text.Json.Serialization;
using Core.SharedContext.Entities;
using Core.VaccineCardContext.Entities;
using Core.VaccineContext.Enums;
using Core.VaccineContext.Errors;
using Core.VaccineContext.Errors.Exceptions;
using Core.VaccineContext.ValueObjects;

namespace Core.VaccineContext.Entities;

public class Vaccine : Entity
{
    public VaccineName vacciName { get;  }
    public Manufacturer Manufacturer { get;  }  // Ex: "Butantan", "Pfizer"
    public VaccineCategory CategoryType { get;  }      // Ex: "Infantil", "Adulto"
    public VaccineDose DoseType { get;  }      // Ex: "1ª Dose", "Reforço"
    public int? MinimumAgeInMonths { get;  }
    public bool IsMandatory { get;  }
    public string Index { get; }
    

    #region Constructors

    private Vaccine(): base(Guid.NewGuid())
    {
        
    }
    [JsonConstructor]
    private Vaccine(VaccineName name, Manufacturer manufacturer, VaccineCategory category,VaccineDose dose , int? minimumAgeInMonths, bool isMandatory , string index) : base(Guid.NewGuid())
    {
        vacciName = name;
        Manufacturer = manufacturer;
        CategoryType = category;
        DoseType = dose;
        MinimumAgeInMonths = minimumAgeInMonths;
        IsMandatory = isMandatory;
        Index = index;
    }

    #endregion

    #region Factory

    public static Vaccine Create(VaccineName vaccineName, Manufacturer manufacturer, VaccineCategory categoryType, VaccineDose doseType, int? minimumAgeInMonths, bool isMandatory, string index)
    {
        
        
        Validate(vaccineName, manufacturer, categoryType, doseType, isMandatory, index);
        return  new Vaccine(vaccineName, manufacturer, categoryType, doseType, minimumAgeInMonths, isMandatory,index);
    }

    #endregion

    #region Methods

    private static void Validate(VaccineName vaccineName, Manufacturer manufacturer, VaccineCategory categoryType, VaccineDose doseType, bool isMandatory,string index)
    {
        if (string.IsNullOrEmpty(vaccineName) || string.IsNullOrWhiteSpace(vaccineName))
            throw new VaccineNameInvalidLengthException(ErrorMessageVaccine.VaccineName.InvalidNullOrEmpty);
        
        if (string.IsNullOrEmpty(manufacturer) || string.IsNullOrWhiteSpace(manufacturer))
            throw new ManufactureInvalidException(ErrorMessageVaccine.Manufacturer.InvalidNullOrEmpty);
        
        if (!Enum.IsDefined(typeof(VaccineCategory), categoryType))
            throw new VaccineCategoryInvalidException(ErrorMessageVaccine.VaccineCategory.Invalid);
        
        if (!Enum.IsDefined(typeof(VaccineDose), doseType))
            throw new VaccineDoseInvalidException(ErrorMessageVaccine.VaccineDose.Invalid);
       
    }

    #endregion
   
}