

namespace EFPayroll;

public class Contractor : HumanResource
{
    public Contractor() 
    { }
    public Contractor(string firstName, string lastName, double rate, DateTime hireDate)
       : base(firstName, lastName, hireDate)
    {
        Rate = rate;
    }

    public double Rate { get; set; }

    public override double Pay()
    {
        return Rate * 50;
    }
}
