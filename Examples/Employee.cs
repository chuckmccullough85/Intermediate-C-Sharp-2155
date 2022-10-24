using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class Employee
    {
        private string firstName="";
        private string lastName="";
        private double salary=0;
        private const double TAX_RATE = .0765;


        public Employee()
            :this ("", "", 0)
        { }

        public Employee(string firstName, string lastName, double salary)
        {
            FirstName = firstName;
            LastName = lastName;    
            Salary = salary;
        }

        public string FirstName 
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public DateTime HireDate { get; set; }
        public string FullName => $"{LastName}, {FirstName}";

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        double Pay() => Salary - Salary * TAX_RATE;

    }
}
