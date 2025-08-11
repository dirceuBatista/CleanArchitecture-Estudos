using Core.VaccineContext.Enums;

namespace Core.test.VaccineContext.Enums;

public class VaccineDoseTest
{
    [Fact]
    public void VaccineCategory_Should_Have_All_Expected_Values()
    {
        var values = Enum.GetValues(typeof(VaccineDose)).Cast<VaccineDose>().ToList();

        Assert.Contains(VaccineDose.First, values);
        Assert.Contains(VaccineDose.Second, values);
        Assert.Contains(VaccineDose.Third, values);
        Assert.Contains(VaccineDose.Reinforcement, values);

        Assert.Equal(4, values.Count); 
    }
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public void Should_Convert_Int_To_Valid_VaccineCategory(int value)
    {
        bool isDefined = Enum.IsDefined(typeof(VaccineDose), value);

        Assert.True(isDefined);
    }

    [Fact]
    public void Should_Fail_When_Int_Is_Invalid_Enum()
    {
        int invalidValue = 99;

        bool isDefined = Enum.IsDefined(typeof(VaccineDose), invalidValue);

        Assert.False(isDefined);
    }

    [Fact]
    public void VaccineCategory_ToString_Should_Return_Name()
    {
        var category = VaccineDose.First;

        Assert.Equal("First", category.ToString());
    }
}