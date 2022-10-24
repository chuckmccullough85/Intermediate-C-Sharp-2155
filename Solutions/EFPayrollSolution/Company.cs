namespace EFPayroll
{
    public class Company : Payable
    {
        public Company()
        {

        }
        public Company(string name, string taxId)
        {
            Name = name;
            TaxId = taxId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }
        public virtual ICollection<Payable> Resources 
            {get;set;} = new HashSet<Payable>();
        public void Hire(Payable emp)
        {
            Resources.Add(emp);
        }
        public override double  Pay() => Resources.Sum(r => r.Pay());
    }
}
