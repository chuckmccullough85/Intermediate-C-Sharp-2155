
using System.Text.RegularExpressions;

namespace FirstLab
{
    // on new Employee
    // allocate memory for the object
    // set each field to default (null, 0, false, today for datetime)
    // set any in-place initializer
    // invoke constructor

    public class Employee
    {
        public const double TAX_RATE = .0765;
        private string firstName;
        private string lastName;
        private double salary = 1;

        public Employee(string firstName, string lastName, double salary,  DateTime hireDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            HireDate = hireDate;
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (Regex.IsMatch(value, @"^[\w\s'-]{1,30}$"))
                    firstName = value;
                else throw new ArgumentException("Invalid FirstName");
            }
        }
        public string LastName
        {
            set { lastName = value; }
            get { return lastName; }
        }
        public double Salary
        {
            get => salary;
            set => salary = value;
        }
        public double YtdGrossPay { get; private set; }  // compiler generated backing field init (0)
        public DateTime HireDate { get; init; }

        public double Pay()
        {
            var tax = Salary * TAX_RATE;
            YtdGrossPay += Salary;
            var net = Salary - tax;
            return net;
        }

        public override string ToString() => $@"{FirstName} {LastName} makes {Salary:c} and has made {YtdGrossPay:c} so far ytd. 
{FirstName} was hired on {HireDate}";
    }
}
