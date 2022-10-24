namespace EFPayroll
{
    public class Company : IPayable
    {
        public Company(string name, string taxId)
        {
            Name = name;
            TaxId = taxId;
        }

        public string Name { get; set; }
        public string TaxId { get; set; }
        public GenericArrayList<IPayable> Children { get; set; } = new();
        public void Add(IPayable emp)
        {
            Children.Add(emp);
        }
        public double Pay()
        {
            double total = 0;
            for (int i=0; i<Children.Size; i++)
            {
                total += Children[i].Pay();
            }
            return total;
        }
    }
}
