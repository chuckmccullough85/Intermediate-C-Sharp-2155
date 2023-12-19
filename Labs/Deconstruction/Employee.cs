namespace Deconstruction;

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

    public override string ToString()
    {
        return $"""
                An Employee, {LastName}, {FirstName} with a Salary of {Salary:c}
                has made {YtdGrossPay:c}.  {FirstName} was hired on {HireDate:D}
                """;
    }
}
