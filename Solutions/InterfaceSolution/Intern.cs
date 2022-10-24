
namespace EFPayroll
{
    public class Intern : HumanResource
    {
        public Intern(string firstName, string lastName, DateTime hireDate)
           : base(firstName, lastName, hireDate)
        {

        }

        public override double Pay()
        {
            return 50;
        }
    }
}
