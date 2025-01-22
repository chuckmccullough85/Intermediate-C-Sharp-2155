using System.Text.RegularExpressions;

namespace EFPayroll
{
    public class Employee : IEmployee
    {
        public delegate double LocalTaxFunc(double amt);
        public delegate void NotifyPay(Employee emp, double net);
        public event NotifyPay? OnPay;

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
            if (hireDate < DateTime.Now)
                HireDate = hireDate;
            else throw new ArgumentException("Hire date must be in the past");
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
            set
            {
                if (Regex.IsMatch(value, @"^[\w\s'-]{1,30}$"))
                    lastName = value;
                else throw new ArgumentException("Invalid LastName");
            }
            get { return lastName; }
        }
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
        public double YtdGrossPay
        {
            get; private set;
        }
        public DateTime HireDate { get; init; }
        public int Tenure
        {
            get
            {
                var years = DateTime.Now.Year - HireDate.Year;
                if (DateTime.Now.DayOfYear < HireDate.DayOfYear) years--;
                return years;
            }
        }

        // placeholder - change as needed
        public LocalTaxFunc? LocalTaxMethod { get; set; }

        public double Pay()
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
}
