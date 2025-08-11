using Core.VaccineContext.Enums;

namespace Core.test.VaccineContext.Enums;

public class VaccineCategoryTest
{
    [Fact]
    public void VaccineCategory_Should_Have_All_Expected_Values()
    {
        var values = Enum.GetValues(typeof(VaccineCategory)).Cast<VaccineCategory>().ToList();

        Assert.Contains(VaccineCategory.Adult, values);
        Assert.Contains(VaccineCategory.kid, values);
        Assert.Contains(VaccineCategory.Old, values);

        Assert.Equal(3, values.Count); 
    }
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Should_Convert_Int_To_Valid_VaccineCategory(int value)
    {
        bool isDefined = Enum.IsDefined(typeof(VaccineCategory), value);

        Assert.True(isDefined);
    }
    [Fact]
    public void Should_Fail_When_Int_Is_Invalid_Enum()
    {
        int invalidValue = 99;

        bool isDefined = Enum.IsDefined(typeof(VaccineCategory), invalidValue);

        Assert.False(isDefined);
    }
    [Fact]
    public void VaccineCategory_ToString_Should_Return_Name()
    {
        var category = VaccineCategory.Old;

        Assert.Equal("Old", category.ToString());
    }




}