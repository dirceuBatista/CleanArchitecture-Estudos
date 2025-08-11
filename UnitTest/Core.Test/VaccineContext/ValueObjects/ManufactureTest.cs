using Core.VaccineContext.ValueObjects;

namespace Core.test.VaccineContext.ValueObjects;

public class ManufactureTest
{
    
    [Fact]
    public void Should_Create_Manufacturer_With_Valid_Enterprise()
    {
     
        var enterprise = "Pfizer";
        var manufacturer = Manufacturer.Create(enterprise);
        Assert.Equal(enterprise, manufacturer.Enterprise);
    }

    [Fact]
    public void ToString_Should_Return_Enterprise_Name()
    {
       
        var manufacturer = Manufacturer.Create(" Butantan ");

        var result = manufacturer.ToString();

        Assert.Equal("Butantan", result); 
    }

    [Fact]
    public void Implicit_Conversion_To_String_Should_Return_Enterprise_Name()
    {
       
        var manufacturer = Manufacturer.Create("Fiocruz");
        string result = manufacturer;
        Assert.Equal("Fiocruz", result);
    }

    [Fact]
    public void Two_Manufacturers_With_Same_Enterprise_Should_Be_Equal()
    {
   
        var m1 = Manufacturer.Create("Moderna");
        var m2 = Manufacturer.Create("Moderna");
        Assert.Equal(m1, m2);
    }

    [Fact]
    public void Two_Manufacturers_With_Different_Enterprise_Should_Not_Be_Equal()
    {
        var m1 = Manufacturer.Create("AstraZeneca");
        var m2 = Manufacturer.Create("Pfizer");

        Assert.NotEqual(m1, m2);
    }
}