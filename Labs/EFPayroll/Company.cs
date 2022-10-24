namespace EFPayroll
{
    public class Company : IPayable
    {
        private HashSet<IPayable> resources = new();
        public Company(string name, string taxId)
        {
            Name = name;
            TaxId = taxId;
        }

        public string Name { get; set; }
        public string TaxId { get; set; }
        public IEnumerable<IPayable> Resources => resources;
        public void Hire(IPayable emp)
        {
            resources.Add(emp);
        }
        public double Pay() => Resources.Sum(r => r.Pay());
    }
}
