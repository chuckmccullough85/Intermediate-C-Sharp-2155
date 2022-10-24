

using GenericsLab;

namespace MoqLab
{
    public class Company
    {
        public Company(string name, string taxId)
        {
            Name = name;
            TaxId = taxId;
        }

        public string Name { get; set; }
        public string TaxId { get; set; }
        public GenericArrayList<IEmployee> Employees { get; set; } = new();
        public void Hire(IEmployee emp)
        {
            Employees.Add(emp);
        }
        public double Pay()
        {
            double total = 0;
            for (int i=0; i<Employees.Size; i++)
            {
                total += Employees[i].Pay();
            }
            return total;
        }
    }
}
