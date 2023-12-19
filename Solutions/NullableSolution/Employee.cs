namespace Deconstructor;

public class Employee
{
    private const double TAX_RATE = .0765;
    private string firstName = "";
    private string lastName = "";
    private double salary = 0;

    public Employee(string firstName, string lastName, double salary, DateTime hireDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Salary = salary;
        YtdGrossPay = 0;
        HireDate = hireDate;
    }
    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    public string LastName
    {
        get => lastName;
        set => lastName = value;
    }
    public string? MiddleName { get; set; }

    public double Salary
    {
        get => salary;
        set => salary = value;
    }
    public double YtdGrossPay
    {
        get; private set;
    }
    public DateTime HireDate { get; init; }

    public double Pay()
    {
        YtdGrossPay += Salary;
        return Salary - Salary * TAX_RATE;
    }

    public void Deconstruct (out string FullName, out double Salary, out double YtdGross )
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
