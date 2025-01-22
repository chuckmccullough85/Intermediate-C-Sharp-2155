using System.ComponentModel.DataAnnotations.Schema;

namespace EFPayroll;

public class Employee : HumanResource
{
    public delegate double LocalTaxFunc(double amt);
    public delegate void NotifyPay(Employee emp, double net);
    public event NotifyPay? OnPay;

    private const double TAX_RATE = .0765;
    private double salary = 0;

    public Employee(string firstName, string lastName, double salary, DateTime hireDate)
        : base(firstName, lastName, hireDate)
    {
        Salary = salary;
    }
    public Employee()
    { }

    public double Salary
    {
        get => salary;
        set
        {
            if (value < 50 || value > 500)
                throw new ArgumentOutOfRangeException();
            salary = value;
        }
    }


    [NotMapped]
    public LocalTaxFunc? LocalTaxMethod { get; set; }

    public override double Pay()
    {
        var sal = Tenure >= 5 ? Salary * 1.02 : Salary;
        YtdGrossPay += sal;
        var tax = sal * TAX_RATE;
        if (LocalTaxMethod != null)
            tax += LocalTaxMethod(sal);
        if (OnPay != null)
            OnPay(this, sal - tax);
        return sal - tax;
    }

    public void Deconstruct(out string FullName, out double Salary, out double YtdGross)
    {
        FullName = $"{FirstName} {LastName}";
        Salary = this.Salary;
        YtdGross = this.YtdGrossPay;
    }
    public void Deconstruct(out string FirstName, out string LastName, out double Salary,
        out double YtdGross, out DateTime HireDate)
    {
        FirstName = this.FirstName;
        LastName = this.LastName;
        Salary = this.Salary;
        YtdGross = this.YtdGrossPay;
        HireDate = this.HireDate;
    }

}
