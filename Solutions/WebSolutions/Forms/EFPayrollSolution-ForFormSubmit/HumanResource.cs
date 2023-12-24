
using ExtensionMethods;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFPayroll;

public abstract class HumanResource : Payable
{
    private string firstName = "";
    private string lastName = "";

    public HumanResource()
    { }
    public HumanResource(string firstName, string lastName, DateTime hireDate)
    {
        FirstName = firstName;
        LastName = lastName;
        YtdGrossPay = 0;
        if (hireDate < DateTime.Now)
            HireDate = hireDate;
        else throw new ArgumentException("Hire date must be in the past");
    }
    public string FirstName
    {
        get => firstName;
        set
        {
            value.Validate(@"[\w\s'-]{1,30}", "Invalid FirstName");
            firstName = value;
        }
    }
    public string LastName
    {
        set
        {
            value.Validate(@"[\w\s'-]{1,30}", "Invalid LastName");
            lastName = value;
        }
        get { return lastName; }
    }
    public double YtdGrossPay
    {
        get; protected set;
    }
    public DateTime HireDate { get; init; }

    [NotMapped]
    public int Tenure
    {
        get
        {
            var years = DateTime.Now.Year - HireDate.Year;
            if (DateTime.Now.DayOfYear < HireDate.DayOfYear) years--;
            return years;
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is HumanResource resource &&
               FirstName == resource.FirstName &&
               LastName == resource.LastName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName);
    }

    public static bool operator == (HumanResource h1, HumanResource h2)
        => h1.Equals(h2);
    public static bool operator != (HumanResource h1, HumanResource h2) 
        => !(h1 == h2);

}
